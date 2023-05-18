from fastapi import FastAPI, File, UploadFile
import io
import numpy as np
from PIL import Image
import torch
import torch.nn as nn
import torch.nn.functional as F
import torch.optim as optim

print("Loading model...")
class Network(nn.Module):
    def __init__(self):
        super(Network, self).__init__()
        self.conv1 = nn.Conv2d(1, 10, 3)
        self.pool1 = nn.MaxPool2d(2)

        self.conv2 = nn.Conv2d(10, 20, 3)
        self.pool2 = nn.MaxPool2d(2)

        self.conv3 = nn.Conv2d(20, 30, 3)
        self.dropout1 = nn.Dropout2d()

        self.fc3 = nn.Linear(30 * 3 * 3, 270)
        self.fc4 = nn.Linear(270, 26)

        self.softmax = nn.LogSoftmax(dim=1)

    def forward(self, x):
        x = self.conv1(x)
        x = F.relu(x)
        x = self.pool1(x)

        x = self.conv2(x)
        x = F.relu(x)
        x = self.pool2(x)

        x = self.conv3(x)
        x = F.relu(x)
        x = self.dropout1(x)

        x = x.view(-1, 30 * 3 * 3)
        x = F.relu(self.fc3(x))
        x = F.relu(self.fc4(x))

        return self.softmax(x)

# Instantiate the new model and load the trained model
model = Network()
model.load_state_dict(torch.load('model.pt'))
model.eval()
print("Model loaded")

app = FastAPI()

@app.post("/files")
async def create_file(file: bytes = File(...)):
    # Convert to numpy array and print shape
    img = Image.open(io.BytesIO(file)).convert('L')
    img = img.resize((28, 28))
    img = np.array(img)
    print(img.shape)

    # Convert to tensor and print shape
    img = torch.from_numpy(img)
    img = img.unsqueeze(0).unsqueeze(0).float()  # Convert the tensor to float
    img /= 255.0  # Normalize the values to the range [0, 1]
    print(img.shape)

    # Use the new model and print prediction
    with torch.no_grad():
        output = model(img)
        res = torch.argmax(output).item()
    return str(res)
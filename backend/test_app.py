import requests

# Upload an image file and classify it
url = 'http://localhost:8000/classify'
files = {'image': open('sample.png', 'rb')}
response = requests.post(url, files=files)
print(response.json())
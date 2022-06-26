from flask import Flask
from flask import request
from flask import jsonify,make_response
import detect
import base64
import os
app = Flask(__name__)



@app.route('/api/obradisliku',methods = ['POST','GET'])

def hello():
    print(request.headers)
    slikaB64=request.json["slika"].encode("utf-8")
    slikaBytes=base64.decodebytes(slikaB64)
    
    with open('slika.jpg', 'wb') as file_to_save:
        file_to_save.write(slikaBytes)

    objekti = detect.run(weights="best.pt",source="slika.jpg",project=os.path.join(os.getcwd(),"Slika"))
    with open(os.path.join(os.getcwd(),"Slika","slika.jpg"), "rb") as image_file:
        imaageBytes = base64.b64encode(image_file.read())
        decoded_string = imaageBytes.decode("utf-8")
        print(objekti)
        return make_response(jsonify(spisakObjekata=objekti,slika=decoded_string),200)

if __name__ == "__main__":
    app.run(host="0.0.0.0",debug=False)

#!/usr/bin/env python

import socket

HOST = "localhost"
PORT = 8080

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((HOST, PORT))
myStr="Hello\n"
methodName=input("Type Method to execute")+"\n"
fileName=input("Type file Name")+"\n"
content=input("Type content for file")+"\n"
methodNameBytes = str.encode(methodName)
fileNameBytes = str.encode(fileName)
contentBytes = str.encode(content)
#type(stringBytes)
sock.sendall(methodNameBytes)
sock.sendall(fileNameBytes)
sock.sendall(contentBytes)

data = sock.recv(1024)
print ("1)", data)

if ( data == "olleH\n" ):
    sock.sendall("Bye\n")
    data = sock.recv(1024)
    print ("2)", data)

    if (data == "eyB}\n"):
        sock.close()
        print ("Socket closed")

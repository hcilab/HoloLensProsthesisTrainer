import socket


HOST = 'localhost'
PORT = 5555

client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

client_socket.connect((HOST,PORT))

string = ""

while 1:
    data = client_socket.recv(1024)
    decodedData = data.decode('utf-8')
    if decodedData == ";":
        print(string)
        string = ""
    else:
        string += decodedData + " "
    
    #print(decodedData + "\n")
    if not data:
        break

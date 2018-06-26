import socket
import sys

host = '127.0.0.1'
port = 5555
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:
    s.bind((host,port))
except socket.error as e:
    print(str(e))

s.listen(1)
conn, addr = s.accept()

print('connected to: '+addr[0]+':'+str(addr[1]))
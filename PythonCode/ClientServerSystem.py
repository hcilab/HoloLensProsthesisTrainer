import socket
import sys
from _thread import *

host = '127.0.0.1'
port = 5555
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:
    s.bind((host,port))
except socket.error as e:
    print(str(e))

s.listen(5)
print('waiting for a connection.')


while True:

    conn, addr = s.accept()
    print('connected to: '+addr[0]+':'+str(addr[1]))

    start_new_thread(threaded_client,(conn,))


def threaded_client(conn):
    conn.send(str.encode('Welcome, type your info\n'))
    things = ''

    while True:
        data = conn.recv(2048)
        things = things + data.decode('utf-8')
        for string in data.decode('utf-8'):
            if string == '\n':
                reply = 'Server output: ' + things
                things = ''
                conn.sendall(str.encode(reply))
        
        if not data:
            break
    
    conn.close()

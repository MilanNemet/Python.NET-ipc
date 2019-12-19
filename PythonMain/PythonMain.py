import socket

UDP_IP = "127.0.0.2"
UDP_PORT = 50500
MESSAGE =   """
Helló belló!
Mi újság mostanság?  """

b_arr = bytearray(MESSAGE.encode())




remote_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
remote_socket.sendto(b_arr, (UDP_IP, UDP_PORT))


#remote_socket.bind(UDP_IP, UDP_PORT)
while True:
    data, addr = remote_socket.recvfrom(1024) # buffer size is 1024 bytes
    print ("received message:\n\n", data.decode("utf-8"))
    print("\n"+"This message was sent from: ", addr)



input(prompt)

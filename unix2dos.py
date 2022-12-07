#!/usr/bin/python
b="";
c="";
print("\033c\033[42;30m\n");
print ("file to convert?");
b=raw_input();
try:
	f=open(b,"r");
	c=f.read();
	f.close();
	c=c.replace("\n","\r\n");
	f=open(b+".tx","w");
	f.write(c);
	f.close();
except:
	print("file error");
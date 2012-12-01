import clr
from System.Diagnostics import Process
import csv

procs = Process.GetProcesses()
with open('processes.csv', 'wb') as csvfile:
	writer = csv.writer(csvfile)
	for p in procs:
	  writer.writerow([p.ProcessName, str(p.PrivateMemorySize64 / 1024) + " kB"])

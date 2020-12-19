import os
import sys

# filenameParam = sys.argv[1]
filenameParam = 'CommonWebApi'

print(filenameParam)
rootPath = os.getcwd()
oryginalProjectName = 'somenew'

for root, dirs, files in os.walk(rootPath):
    for filename in files:
        if(oryginalProjectName in filename):
            old_fullFileName = root + "/" + filename
            newFileName = filename.replace(oryginalProjectName, "HealthShield.QRCode.Service")
            new_fullFileName = root + "/" + newFileName
            os.rename(old_fullFileName, new_fullFileName)

import os
import sys

pathPart_to_change = sys.argv[1]
newPhrase = sys.argv[2]

def rename_files(oldName, newName):
    rootPath = os.getcwd()

    result = []
    for root, dirs, files in os.walk(rootPath):
        for filename in files:
            if(oldName in filename):
                old_fullFileName = root + "/" + filename
                newFileName = filename.replace(oldName, newName)
                new_fullFileName = root + "/" + newFileName
                # os.rename(old_fullFileName, new_fullFileName)
                result.append({old_fullFileName, new_fullFileName})

    return result

print(rename_files(pathPart_to_change, newPhrase))

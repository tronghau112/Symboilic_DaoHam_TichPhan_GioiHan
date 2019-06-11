rem display.bat 
rem %1 represents the file name with no extension
pdflatex -jobname=output %1
convert output.pdf output.png
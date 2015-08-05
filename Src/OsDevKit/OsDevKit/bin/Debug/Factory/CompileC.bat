setlocal
set opt=-w -m32 -Wall -O -fstrength-reduce  -finline-functions -fomit-frame-pointer -nostdinc -fno-builtin -I %3 -c -fno-strict-aliasing -fno-common -fno-stack-protector
cd Factory
cd ..
cd Tools
cd Bin
gcc.exe %opt% -o ..\..\Factory\Build\%2.o %1 
cd ..
cd ..
cd Factory
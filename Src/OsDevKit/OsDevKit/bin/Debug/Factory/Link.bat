cd Factory
cd ..
cd Tools
cd Bin
ld.exe -melf_i386 -T ..\..\Factory\linker.ld ..\..\Factory\Build\*.o
copy kernel.bin ..\..\Factory\CD\
cd ..
cd ..
cd Factory
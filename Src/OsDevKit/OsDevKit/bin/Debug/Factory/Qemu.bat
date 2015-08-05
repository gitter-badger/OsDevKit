cd Factory
cd qemu
qemu.exe -L . -fda %1 -serial tcp:127.0.0.1:8080,server,nowait
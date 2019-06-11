packageDir:= cat(currentdir(), kernelopts(dirsep) , "DoAn.mla"):
march('open', packageDir):
A := Limit((x-1)/(x-1)^2, x = 1);
S := GiaiChiTiet(A);
XuatLoiGiai(A, S, true);

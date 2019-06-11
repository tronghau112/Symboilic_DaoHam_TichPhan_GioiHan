packageDir:= cat(currentdir(), kernelopts(dirsep) , "DoAn.mla"):
march('open', packageDir):
A := Limit(ln (cos x)/ln (1+x^2), x = 0);
S := GiaiChiTiet(A);
XuatLoiGiai(A, S, true);

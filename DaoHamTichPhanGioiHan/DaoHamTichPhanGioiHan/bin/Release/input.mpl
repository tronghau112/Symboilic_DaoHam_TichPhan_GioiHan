packageDir:= cat(currentdir(), kernelopts(dirsep) , "DoAn.mla"):
march('open', packageDir):
A := Diff(sum(f,i=n)((x+1)/(x^3+1)), x);
S := GiaiChiTiet(A);
XuatLoiGiai(A, S, true);

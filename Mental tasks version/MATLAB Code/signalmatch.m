function authparam = signalmatch(file1 , file2)
x = feature_extract(file1);
y = feature_extract(file2);
ratioxy = x./y;
for i =1:size(ratioxy)
    if((ratioxy(:,i) < 0.2) || (ratioxy(:,i) > 2))
        authparam = 0;
        return;
    end
end
if((sum(ratioxy) > 4.2) && (sum(ratioxy) < 8.6))
    authparam = 1;
else
    authparam = 0;
end
end
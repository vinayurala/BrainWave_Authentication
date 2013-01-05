function ar_coeff = calc_ar_coeff(file)
% calc_ar_coeff(file) returns 6 AR co-efficients, using Burg's 
% method, of the EEG signal passed as parameter 'file'.
% This function calculates the mean of the AR co-efficients
% obtained. 
% Reference: Palaniappan's paper, Section 3.1
data = readedf(file);
ar_coeff = zeros(14,7);
x = zeros(14 , length(data));
for i=3:16
    x(i-2,:) = data(i,:);
end
for i=1:14
    % Calculate AR co-efficients of order 6 using Burg's method
    ar_coeff(i,:) = arburg(x(i,:) , 6);
end
ar_coeff(:,1) = [];
end
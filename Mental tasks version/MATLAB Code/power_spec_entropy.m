function power_spec_entropy = power_spec_entropy(file)
% power_spec_entropy(file) returns the Power Spectral Entropy(PSE)
% of the EEG signal passed as parameter 'file'.
% This feature was not suggested by Palaniappan, however 
% another paper(see ref) claims that it is a good classification
% measure. I could only access the abstract and I am not sure
% if this was the way how they calculated PSE.
% This module, like all others, returns the mean value of the power
% spectral entropy of 14 channels.
% References: http://www.dsprelated.com/showmessage/108326/1.php(Third 
%             Reply)
%             http://www.computer.org/portal/web/csdl/doi/10.1109/BMEI.2008
%             .254
data = readedf(file);
power_spec_entropy = zeros(14,6);
x = data(3:16,:);
for i=1:14 
N = length(x(i,:));
xf = abs(fft(x(i,:))) / N;
% Obtain the power spectrum 
Px = xf.*xf;
% Normalize the power spectrum 
Qx = Px / sum(Px);
% Transform with Shannon function 
Hx = Qx.*log(1./Qx);
% Power Spectral Entropy. 
Entrx = sum(Hx) / log(3);

% Mean PSE value is multiplied by 100 to increase the resolution
power_spec_entropy(i,:) = [ Entrx.*10000 , 0 , 0 , 0 , 0 , 0];
end
end
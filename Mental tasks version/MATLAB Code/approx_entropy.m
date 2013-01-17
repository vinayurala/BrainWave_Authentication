function approx_entropy = approx_entropy(file)
% approx_entropy(file) returns the approximate entropy of the
% EEG signal, which is passed as the parameter 'file'.
% Approxiamte Entropy:Quantifies the predictability of subsequent  
% amplitude values ofthe EEG based on the knowledge of previous 
% amplitude values.
% Lower the value of Approx. Entropy, higher is its predictability
% and vice versa.
% This module executes pretty slowly compared to other modules.
% The range of execution time is between 15 seconds to a minute
% on my comp. 
% This module returns the mean of the approximate entropy of the
% 14 channels.
% Reference : Palaniappan's paper, Section 3.4
%           : http://www.macalester.edu/~kaplan/hrv/doc/funs/apen.html
data = readedf(file);
m = 2;
lag  = 1;
approx_entropy = zeros(14,6);
for i=3:16
    edata = lagEmbed(data(i,:) , m , lag);
    [pre , post] = getimage(edata , lag);
    r = .15 * std(data(i,:));
    approx_entropy(i-2,1) = apen(pre , post ,r);
end
end
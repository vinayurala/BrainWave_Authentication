function channel_spec_power = channel_spectral_power(file)
[data,header]=readedf(file);
N=size(data);
N=N(2);%no of sample points
T=header.records;%recording time
channel_spec_power = zeros(14,6);
for i=3:16
    f = data(i,:); %%define function
    p = abs(fft(f))/(N/2); %% absolute value of the fft
    p = p(1:N/2).^2; %% take the power of positve freq. half
    freq = (0:N/2-1)/T; %% find the corresponding frequency in Hz

channelpower=0;
l=size(freq);
l=l(2);
for j=1:l
    channelpower=channelpower+ p(j)*freq(j);
end
alphapower=0;
betapower=0;
gammapower=0;
for j=1:l
    if(freq(j)>=7&&freq(j)<13)
        alphapower=alphapower+p(j)*freq(j);
    elseif(freq(j)>=13&&freq(j)<30)
        betapower=betapower+p(j)*freq(j);
    elseif(freq(j)>=30&&freq(j)<=64)
        gammapower=gammapower+p(j)*freq(j);
    end
end
channel_spec_power(i-2,:) = [alphapower , betapower , gammapower , 0 , 0 , 0];
end
end
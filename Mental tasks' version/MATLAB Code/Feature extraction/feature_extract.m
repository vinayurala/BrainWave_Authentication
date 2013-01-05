function final_feature_set = feature_extract(file)
% feature_extract(file) returns 4 features of the EEG signal, which
% is passed as parameter 'file'. Only EDF file formats are supported.
% Main entry-point function to extract features from a given EEG
% signal. This function actually calculates the mean values
% all the features extracted from 14 channels. A better way to
% extract features is to retain all of them and then perform
% Principal Component Analysis(PCA) on them. This function only 
% extracts the features and does not compare them. Comparsion has
% to be done manually as of now.
% Reference: Palaniappan's paper, section 3.5
%% Call functions to return the features and conactenate them to
%  a single array feature_set
ar_coeff = calc_ar_coeff(file);
channel_spec_pow = channel_spectral_power(file);
pow_spec_entropy = power_spec_entropy(file);
approx_entr = approx_entropy(file);
feature_set = vertcat(ar_coeff , channel_spec_pow , pow_spec_entropy , approx_entr); 
%% Run PCA to reduce the feature set and obatin the final array
 % final feature set
final_feature_set = pca(feature_set);
final_feature_set = final_feature_set';
fprintf('Final Feature Set = ');
disp(final_feature_set);
end
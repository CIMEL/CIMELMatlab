function[]=test_arguments(att)
diary('test_arguments.log');
diary off;
%att={'strong',[],'wind',[],'overcast','weak',[]}; 
if att
    disp('true');
else
    disp('false');
end

fprintf('isempty=%d',isempty(att));
%a1 = att;
%a1(t)
%a1(t) = {0};
%diary off
end
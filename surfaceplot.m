% sample from the official
%{
[X,Y] = meshgrid(1:0.5:10,1:20);
Z = sin(X) + cos(Y);
surf(X,Y,Z)
%}
% sample I learned
%{
X=[100,200,300;100,200,300;100,200,300]
X
Y=[1,2,3;3,4,5;5,6,7]
Y
%[X,Y]=meshgrid([[1,2,3],[3,4,5],[,5,6,7]],100:100:300)
Z=[1,2,3;1,2,3;1,2,3]
Z
surf(X,Y,Z)
%}
%sample with AAOD.2017.3.1-4.data of ningbo
%options=440,675,870,1020,550
options=[440,675,870,1020,550]; % n=5
%days = 4 days
days=[1,2,3,4]; % m=4
%times = time points per day
times1=[
    0.0454,0.0296,0.0254,0.0254,0.0364;
    0.0199,0.0142,0.0101,0.0091,0.0167;
    0.0172,0.0102,0.0077,0.0067,0.0131;
    0.0351,0.0213,0.0157,0.0147,0.0271
    ];% m:n=size(times), 4:5
times2=[
    0.0452,0.0243,0.0189,0.0225,0.0327;
    0.0018,0.0011,0.0009,0.0007,0.0014;
    0.0116,0.0072,0.0052,0.0045,0.0090;
    0.0314,0.0187,0.0141,0.0127,0.0240
    ];
%{
CO(:,:,1) = zeros(25); % red
CO(:,:,2) = ones(25).*linspace(0.5,0.6,25); % green
CO(:,:,3) = ones(25).*linspace(0,1,25); % blue
%}
figure
s1=surf(options,days,times1,'FaceColor','g','LineStyle',':', 'FaceAlpha',0.8, 'EdgeColor','none');
hold on
s2=surf(options,days,times2,'FaceColor','r', 'FaceAlpha',0.8, 'EdgeColor','none');

zlabel('Data Observed');
xlabel('Option Observing');
ylabel('Date (2017-3-1 to 2017-3-4)')
title('AAOD')
legend([s1, s2], {'8:10:01', '9:10:25'});




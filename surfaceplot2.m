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
legends=[440,550,675,870,1020];
%days = 4 days
days=(1:2); % n=2
times=(1:10); % m=10;
%times = time points per day
v1=[
    0.0636,0.0649,0.0662,0.04695,0.037325,0.0277,0.0277,0.0277,0.0277,0.0277;
    0.078,0.078,0.0798,0.0816,0.0662,0.07455,0.0829,0.0951,0.1371,0.1398;
    ];% m:n=size(times), 10:2
v1=v1';

v2=[
    0.0412,0.0403,0.0394,0.03015,0.025525,0.0209,0.0209,0.0209,0.0209,0.0209;
    0.0548,0.0548,0.0554,0.056,0.0438,0.0499,0.056,0.0641,0.0902,0.0957;
    ];
v2=v2';

v3=[
    0.0276,0.01952,0.0245,0.01952,0.01952,0.0162,0.01952,0.01952,0.01952,0.01952;
    0.0397,0.0397,0.0397,0.0397,0.03,0.03455,0.0391,0.0446,0.0614,0.0676;
    ];
v3=v3';

v4=[
    0.0218,0.02055,0.0193,0.01585,0.014125,0.0124,0.0124,0.0124,0.0124,0.0124;
    0.0329,0.0329,0.0324,0.0319,0.0225,0.02605,0.0296,0.0336,0.0484,0.053;
    ];
v4=v4';

v5=[
    0.0217,0.0214,0.0211,0.0159,0.0133,0.0107,0.0107,0.0107,0.0107,0.0107;
    0.0315,0.0315,0.03055,0.0296,0.0196,0.02225,0.0249,0.0286,0.0429,0.0467;
    ];
v5=v5';
%{
CO(:,:,1) = zeros(25); % red
CO(:,:,2) = ones(25).*linspace(0.5,0.6,25); % green
CO(:,:,3) = ones(25).*linspace(0,1,25); % blue
%}
figure
%s1=surf(options,days,times1,'FaceColor','g','LineStyle',':', 'FaceAlpha',0.8, 'EdgeColor','none');
%hold on
%s2=surf(options,days,times2,'FaceColor','r', 'FaceAlpha',0.8, 'EdgeColor','none');
s1=surf(days,times,v1,'FaceColor','g','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
hold on
s2=surf(days,times,v2,'FaceColor','r','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
hold on
s3=surf(days,times,v3,'FaceColor','b','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
hold on
s4=surf(days,times,v4,'FaceColor','y','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
hold on
s5=surf(days,times,v5,'FaceColor','m','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');

zlabel('Data Observed');
xlabel('Option Observing');
ylabel('Date (2017-3-1 to 2017-3-4)')
title('AAOD')
legend([s1, s2,s3,s4,s5], {'440','550','675','870','1020'});




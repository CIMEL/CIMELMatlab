function[file]=DrawSurface(strTitle,optionDatas,dataOptions,arrDates,arrTimes,strFile,verb)
    %sample with AAOD.2017.3.1-4.data of ningbo
    %options=440,675,870,1020,550
    dataOptions1=["440","550","675","870","1020"];
    arrDates1=["2016-12-1","2016-12-2"];
    arrTimes1=["1:2:44","1:4:1","1:18:35","1:19:25","3:19:37","5:19:29","5:20:41","6:19:5","7:18:56","7:39:18"];
%     strTitle1='AAOD';
    color=['m','c','r','g','b','w','k','y',...
           'm','c','r','g','b','w','k','y',...
           'm','c','r','g','b','w','k','y'];
    if verb
        diary('draw_surface.log');
        diary on;
    else
        diary off;
    end
    disp('sample-dataoptions');
    disp(dataOptions1)
    disp('input-dataoptions');
    disp(dataOptions);
    legLabels=dataOptions;
    disp('sample-arrDates');
    disp(arrDates1)
    disp('input-arrDates');
    disp(arrDates)
    strdays=arrDates;
    days=day(datetime(arrDates,'InputFormat','yyyy-MM-dd'));
    disp('days')
    disp(days)

    % convert times to matabl datetime
    disp('sample-arrTimes');
    disp(arrTimes1)
    disp('input-arrTimes');
    disp(arrTimes)
    T=datetime(arrTimes,'InputFormat','hh:mm:ss');

    v1=[
        0.0636,0.0649,0.0662,0.04695,0.037325,0.0277,0.0277,0.0277,0.0277,0.0277;
        0.078,0.078,0.0798,0.0816,0.0662,0.07455,0.0829,0.0951,0.1371,0.1398;
        ];% m:n=size(times), 10:2

    v2=[
        0.0412,0.0403,0.0394,0.03015,0.025525,0.0209,0.0209,0.0209,0.0209,0.0209;
        0.0548,0.0548,0.0554,0.056,0.0438,0.0499,0.056,0.0641,0.0902,0.0957;
        ];

    v3=[
        0.0276,0.01952,0.0245,0.01952,0.01952,0.0162,0.01952,0.01952,0.01952,0.01952;
        0.0397,0.0397,0.0397,0.0397,0.03,0.03455,0.0391,0.0446,0.0614,0.0676;
        ];

    v4=[
        0.0218,0.02055,0.0193,0.01585,0.014125,0.0124,0.0124,0.0124,0.0124,0.0124;
        0.0329,0.0329,0.0324,0.0319,0.0225,0.02605,0.0296,0.0336,0.0484,0.053;
        ];

    v5=[
        0.0217,0.0214,0.0211,0.0159,0.0133,0.0107,0.0107,0.0107,0.0107,0.0107;
        0.0315,0.0315,0.03055,0.0296,0.0196,0.02225,0.0249,0.0286,0.0429,0.0467;
        ];
    
    V1={v1,v2,v3,v4,v5};
    V=optionDatas;

    m=length(V);
    legLines=zeros(1,m);
    g=figure;
    for o=1:m
      v=V{o};
      c=color(o);
      disp(['sample-v',o]);
      disp(V1{o});
      disp(['input-v',o]);
      disp(v);    
      l=surf(days,T,v','FaceColor',c,'LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
      legLines(o)=l;
      hold on
    end
    
%     s1=surf(days,T,v1','FaceColor','g','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
%     hold on
%     s2=surf(days,T,v2','FaceColor','r','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
%     hold on
%     s3=surf(days,T,v3','FaceColor','b','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
%     hold on
%     s4=surf(days,T,v4','FaceColor','y','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');
%     hold on
%     s5=surf(days,T,v5','FaceColor','m','LineStyle','-', 'FaceAlpha',0.5, 'EdgeColor','none');

    %zlabel('Data Observed');
    %xlabel('Option Observing');
    %ylabel('Date (2017-3-1 to 2017-3-4)')
    %title('AAOD')
    title(strTitle)
    
    xlim(days);%X轴取值上限
    xticks(days);%X轴值
    xticklabels(strdays);%X轴标签
    ytickformat('hh:mm');%Y轴标签格式
    legend(legLines,legLabels);%图例
    grid on %显示坐标网格
    set(g,'position',[100 100 800 600]); %图像大小
    set(g,'visible','off');%不显示图像窗口
    saveas(gcf,strFile);%保存
    file=strFile;
    close all;
end




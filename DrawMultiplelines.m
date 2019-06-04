function[file]=DrawMultiplelines(strTitle,optionDatas,dataOptions,arrDates,arrTimes,strFile,verb)
    %sample with AAOD.2017.3.1-4.data of ningbo
    %legLabels={'440','550','675','870','1020'};
    %strdays={'2016-12-1','2016-12-2'};
    %days=[1,2];
    %times={{'1:2:44';'1:18:35';'5:19:29'};{'1:4:1';'1:19:25';'3:19:37';'5:20:41';'6:19:5';'7:18:56';'7:39:18'}};
    %titleLabel='AAOD';
    color=['m','c','r','g','b','w','k','y',...
           'm','c','r','g','b','w','k','y',...
           'm','c','r','g','b','w','k','y'];
    if verb
        diary('draw_multiple_lines.log');
        diary on;
    else
        diary off;
    end
    disp(dataOptions);
    legLabels=cell(dataOptions);
    
    days=zeros(1:length(arrDates));
    for i=1:length(arrDates)
        days(i)=day(datetime(arrDates{i},'InputFormat','yyyy-MM-dd'));
    end
    disp(days);
    
    disp(arrDates);
    strdays=cell(arrDates);
    
    disp(arrTimes);
    times=cell(arrTimes);
    
    %xLabel='Option Observing';
    %zLabel='Data Observed';
    %yLabel='Date (2016-12-1 to 2016-12-2)';
    disp(strTitle);
    titleLabel=strTitle;

    %440
    %v1={[0.0636,0.0662,0.0277];
    %    [0.078,0.0816,0.0662,0.0829,0.0951,0.1371,0.1398]};

    %550
    %v2={[0.0412,0.0394,0.0209];
    %    [0.0548,0.056,0.0438,0.056,0.0641,0.0902,0.0957]};

    %675
    %v3={[0.0276,0.0245,0.0162];
    %    [0.0397,0.0397,0.03,0.0391,0.0446,0.0614,0.0676]};

    %870
    %v4={[0.0218,0.0193,0.0124];
    %    [0.0329,0.0319,0.0225,0.0296,0.0336,0.0484,0.053]};

    %1020
    %v5={[0.0217,0.0211,0.0107];
    %    [0.0315,0.0296,0.0196,0.0249,0.0286,0.0429,0.0467]};

    % convert days to matlab days
    nd=length(days);
    D=cell(1,nd);
    for d=1:nd
        %day=days(d);
        D{d}=ones(1,length(times{d}))*days(d);
    end

    % convert times to matabl datetime
    nt=length(times); % it's must nt==nd
    T=cell(1,nt);
    for t=1:nt
        T{t}=datetime(times{t},'InputFormat','hh:mm:ss');
    end

    %V1={v1;v2;v3;v4;v5};
    V=optionDatas;%cell(V1);

    m=length(V);
    legLines=zeros(1,m);
    g=figure;
    for o=1:m
        v=cell(V{o});
        c=color(o);
        for d = 1:nd
          disp(D{d});
          disp(T{d});
          disp(v{d});
          l=plot3(D{d},T{d},v{d},c);
          if d == 1
              legLines(o)=l;
          end
          hold on
        end
    end

    title(titleLabel)
    % zlabel(zLabel);
    % xlabel(xLabel);
    % ylabel(yLabel)

    xlim(days);%X轴取值上限
    xticks(days);%X轴值
    xticklabels(strdays);%X轴标签
    ytickformat('hh:mm');%Y轴标签格式
    legend(legLines,legLabels);%图例
    grid on %显示坐标网格
    set(g,'position',[100 100 800 600]); %图像大小
    set(g,'visible','off');%不显示图像窗口
    %file= 'figures/multipleline.png';
    saveas(gcf,strFile);%保存
    file=strFile;
    close all; % 清除缓存，防止内存溢出
end
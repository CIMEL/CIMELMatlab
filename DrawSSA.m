function[] = DrawSSA(stats_inversion,r,year,region,outputbase)
%     ssa月平均
fout=outputbase;
YearInCount=year;
stns_fn=region;
wv=[0.44,0.67,0.87,1.02];
ind0=find(stats_inversion(:,1)>=YearInCount & stats_inversion(:,7) >= 0.4 & stats_inversion(:,26) > 0.63); %AOD at 440 > 0.4 and SSA 675 > 0.63
% ind0=find(stats_inversion(:,7) >= 0.4 & stats_inversion(:,26) > 0.63); %AOD at 440 > 0.4 and SSA 675 > 0.63
clev6=stats_inversion(ind0,:);
clev6(:,3)=1;
clev6(:,4:6)=0;
tt=unique(datenum(clev6(:,1:6)));
for i=1:length(tt);
    ind=find(datenum(clev6(:,1:6))==tt(i));
    cmonth(i,1:6)=datevec(tt(i));
  for j=7:length(clev6(1,:)); 
    cmonth(i,j)=nanmean(clev6(ind,j));
  end; 
end;
clear ind;
subplot(3,1,2);
linec=['-c';'-m';'-r';'-g';'-b';'-k';'-y'];
ind=find(cmonth(:,1)>=YearInCount);
plot(datenum(cmonth(ind,1:6)),cmonth(ind,23:26),'-*','markersize',4);hold on;
datetick('x',2);hold on;
set(gca,'xtick',[datenum(2012,1,1) datenum(2012,4,1) datenum(2012,7,1) datenum(2012,10,1) datenum(2013,1,1) datenum(2013,4,1)] ,...
    'xticklabe',{'01/01/12','04/01/12','07/01/12','10/01/12','01/01/13','04/01/13'});
%set(gca,'xtick',[datenum(2012,1,1) datenum(2012,2,1) datenum(2012,3,1) datenum(2012,4,1)],'xticklabe',{'01/01/12','02/01/12','03/01/12','4/01/12'});
    
set(gca,'xlim',[datenum(cmonth(1,1:6))-5 datenum(cmonth(end,1:6))+5]);
set(gca,'xminortick','on','yminortick','on');
grid on;
legend({num2str(wv')},'FontSize',5,'Orientation','horizontal','Location','South');
set(gca,'ylim',[0.7 1]);
xlabel('mm/dd/yy');ylabel('SSA');
title(stns_fn)
eval(['print -dtiff ' fout stns_fn '_ssa_mon.tif']);
close;

%画每天的尺度谱、SSA
wv=[0.44,0.67,0.87,1.02];
 for id=datenum(stats_inversion(1,1:3)):datenum(stats_inversion(end,1:3));
     ind=find(datenum(stats_inversion(:,1:3))==id);
     if(isempty(ind)==0);
         subplot(2,1,1);
         semilogx(r',stats_inversion(ind,43:64),'-*');
         legend([num2str(stats_inversion(ind,7),'%6.2f')]);
         set(gca,'xlim',[0.04 20],'xminortick','on','yminortick','on');
         set(gca,'xtick',[0.05 0.1 0.2 0.5 1.0 2.0 5.0 10.0],'xticklabel',{'0.05','0.1','0.2','0.5','1.0','2.0','5.0','10.0'});
%         
         yyyy=num2str(stats_inversion(ind(1),1));
         if(stats_inversion(ind(1),2)>=10);
             mm=num2str(stats_inversion(ind(1),2));
         else
             mm=['0' num2str(stats_inversion(ind(1),2))];
         end;
         if(stats_inversion(ind(1),3)>=10);
            dd=num2str(stats_inversion(ind(1),3));
         else
             dd=['0' num2str(stats_inversion(ind(1),3))];
         end;
%         
         ind=find(datenum(stats_inversion(:,1:3))==id & stats_inversion(:,7) >=0.4);
         if(isempty(ind)==0);
             subplot(2,1,2);
             plot(wv,stats_inversion(ind,23:26));
             set(gca,'xlim',[0.42 1.05]);
             legend([num2str(stats_inversion(ind,7),'%6.2f')]);
         end;
% 
         eval(['print -dtiff ' fout 'daily_inversion_' yyyy mm dd '.tif']);
         close;
%         
     end;
 end;
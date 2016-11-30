function[]=DrawSSAStatistisc(stats_inversion,r,year,region,outputbase)
%     »æÍ¼
%ssa
% % figure;
fout=outputbase;
stns_fn=region;
YearInCount=year;
wv=[0.44,0.67,0.87,1.02];
subplot(4,1,4);
ind=find(stats_inversion(:,1)>=YearInCount & stats_inversion(:,7) >= 0.4 & stats_inversion(:,26) > 0.63); %AOD at 440 > 0.4 and SSA 675 > 0.63
plot(datenum(stats_inversion(ind,1:6)),stats_inversion(ind,23:26),'-*');hold on;
for im=1:12;
    disp ([YearInCount, im, 30]);
    plot([datenum(YearInCount,im,30),datenum(YearInCount,im,30)],[0.6 1],'-r');
end;
datetick('x',12);hold on;
set(gca,'xlim',[datenum(stats_inversion(ind(1),1:6))-5 datenum(stats_inversion(end,1:6))+5]);
set(gca,'xtick',[datenum(YearInCount,1,1) datenum(YearInCount,2,1) datenum(YearInCount,4,1) datenum(YearInCount,6,1) datenum(YearInCount,8,1) datenum(YearInCount,10,1) datenum(YearInCount,12,1)],...
    'xticklabe',{['Jan',num2str(mod(YearInCount,100))],...
    ['Feb',num2str(mod(YearInCount,100))],['Apr',num2str(mod(YearInCount,100))],...
    ['Jun',num2str(mod(YearInCount,100))],['Aug',num2str(mod(YearInCount,100))]',...
    ['Oct',num2str(mod(YearInCount,100))],['Dec',num2str(mod(YearInCount,100))]});
set(gca,'xminortick','on','yminortick','on');
legend(num2str(wv'),'Orientation','horizontal','Location','South');
set(gca,'ylim',[0.6 1]);
xlabel('Date (MMMYY)');ylabel('SSA');
title(stns_fn)
eval(['print -dtiff ' fout stns_fn '_stats_ssa.tif']);
close;

%size volume
% % figure;
y=[0.05	0.066	0.086	0.113	0.148	0.194	0.255	0.335	0.439	0.576	0.756	0.992	1.302	1.708	2.241	2.94	3.857	5.051	6.641	8.713	11.43	15];
ind=find(stats_inversion(:,1)==YearInCount);
stats_inversion=stats_inversion(ind,:);
for id=1:length(stats_inversion(:,1));
    x=zeros(1,length(y))+datenum(stats_inversion(id,1:6));
    z=stats_inversion(id,43:64);
    plot3(x,y,z,'-b');hold on;
end;
set(gca,'Yscale','Log','xminortick','on','yminortick','on','zminortick','on');
set(gca,'ylim',[0.025 25],'zlim',[0 0.5]);
datetick('x',12);hold on;
zlabel('Volume');
text(datenum(stats_inversion(1,1:6)),25,0.45,stns_fn);
eval(['print -dtiff ' fout stns_fn '_stats_volume.tif']);
close;

pval=prctile(stats_inversion(:,7),[0,25,50,75,100]);
for i=1:4;
    subplot(2,2,i);
    ind=find(stats_inversion(:,7) >=pval(i) & stats_inversion(:,7) <= pval(i+1));
    semilogx(r',nanmedian(stats_inversion(ind,43:64),1),'-b*');
    set(gca,'xlim',[0.05 15],'xminortick','on','yminortick','on');
    set(gca,'xtick',[0.05 0.1 0.2 0.5 1.0 2.0 5.0 10.0],'xticklabel',{'0.05','0.1','0.2','0.5','1.0','2.0','5.0','10.0'});
    grid on;
    tmp=nanmean(stats_inversion(ind,7));
    title(['AOD_4_4_0_n_m = ' num2str(tmp,'%6.2f')]);
    xlabel('Raidus (\mum)');
    ylabel('Volumn concentration (\mum^-^3/\mum^-^2)');
end;
eval(['print -depsc ' fout 'stats_size_distribution.eps']);
close;
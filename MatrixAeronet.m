function[stats_inversion,r]=MatrixAeronet(lat,lon,input,outputfile)
%读取AERONET反演产品
% lat: the lat of the region
% lon: the lot of the region
% input: the base input folder of region
% outputfile: the outputfile
%
% % clear;
% % move to arg
% % stns_fn='hangzhou';
% % move to arg
% % stns_id='808';
% % YearInCount=2013;
%fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
%fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
% % % move the initial logic to C#
% % % fout=output;
% % % if ~exist(fout,'dir')
% % %     mkdir(fout);
% % % end
%fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
fpath=input;
%fpath=['f:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\'];

% % region matrix
% stats={'Beijing';'Dunhuang';'Hefei';'Kunming';'Lasha';'Lanzhou';'Panyu';'Tongyu';'XiangHe';'Xinglong';'Huainan'};
% stns=struct('fn',{'Tongyu','Hefei','Panyu','Kunming','Nanjing','Lasha','Dunhuang','Lanzhou','Xinglong770','Huainan','Fumin'},...
%             'lat',{ 44.42, 31.8333, 23.000, 25.01, 32.200,29.50,40.15, 36.05, 40.396, 32.73, 25.2333},...
%            'lon',{122.92,117.3291,113.354,102.65,118.717,91.13,94.68,103.88,117.578, 117.14, 102.500});
% stns=struct('fn',{'ChunAn','Fuyang','Hangzhou','Jiande','LinAn','Nanjing','Tonglu','Xiaoshan','Chongqing','Pudong'},...
%            'lat',{29.6167, 30.050, 30.23333, 29.4500, 30.2000, 32.05,    29.8000, 30.1833, 29.566, 31.22 },...
%           'lon',{119.0125,119.950,120.17083,119.2750,119.7000,118.77083,119.6667,120.2833,106.463,121.55});
%for is=1:length(stns);
%    if strcmp(stns(is).fn,stns_fn)==1;
%    ifn=is;
%    end;
%end;
stns_lat=lat;%stns(ifn).lat;
stns_lon=lon;%stns(ifn).lon;

%==strmm=['01';'02';'03';'04';'05';'06';'07';'08';'09';'10';'11';'12'];
%==strdd=['01';'02';'03';'04';'05';'06';'07';'08';'09';'10';'11';'12';'13';'14';'15';'16';'17';'18';'19';'20';'21';'22';'23';'24';'25';'26';'27';'28';'29';'30';'31'];
%fidw=fopen([fout 'Dubovik_stats_' stns_fn '_' stns_id '_20130612.dat'],'w');
fidw=fopen(outputfile,'w');
fprintf(fidw,'%s',['year,mm,dd,hh,mm,ss,'...%1:6 UTC
                   'aod440,aod675,aod870,aod1020,'...%7:10
                   'aod550,'....%11
                   'extt440,extt670,extt870,extt1020,'...%12:15
                   'extf440,extf670,extf870,extf1020,'...%16:19
                   'extc440,extc670,extc870,extc1020,'...%20:23
                   'ae440/870,'...%24
                   'ssat440,ssat670,ssat870,ssat1020,'...%25:28
                   'ssat550,'.....%29
                   'ssaf440,ssaf670,ssaf870,ssaf1020,'...%30:33
                   'ssac440,ssac670,ssac870,ssac1020,'...%34:37
                   'aaod440,aaod675,aaod870,aaod1020,'...%38:41
                   'aaod550,'....%42
                   'aae440/870,'...%43
                   'real440,real670,real870,real1020,'...%44:47
                   'imag440,imag670,imag870,imag1020,'...%48:51
                   '0.050,0.066,0.086,0.113,0.148,0.194,0.255,'...
                   '0.335,0.439,0.576,0.756,0.992,1.302,1.708,'...
                   '2.241,2.940,3.857,5.051,6.641,8.713,11.43,15.00,'...%52:73
                   'refft,refff,reffc,'...%74:76
                   'volt,volf,volc,'...%77:79
                   'rmeat,rmeaf,rmeac,'...%80:82
                   'rstdt,rstdf,rstdc,'...%83:85
                   'flxdn1,flxdn2,flxdn3,flxdn4,'...%86:89
                   'flxup1,flxup2,flxup3,flxup4,'...%90:93
                   'sphere,sunerr,skyerr,'......%94:96
                   'brdf440,brdf675,brdf870,brdf1020,'...%添加brdf%97:100
                   'sunzenith,numskyang,']);%101,102
fprintf(fidw,'\n');
                   
stats_inversion=[];
fname=dir([fpath '*.dat']);
for id=1:length(fname);
% for id=1406:1406;
%========================================================
%initialize variable
    daily_inversion=[];
    ssa=zeros(4,3)+NaN;
    ext=zeros(4,3)+NaN;
    aod=zeros(1,4)+NaN;
    sunerr=NaN;
    skyerr=NaN;
    rfre=zeros(4,2)+NaN;
    dv=zeros(1,22)+NaN;
    reff=zeros(1,3)+NaN;
    vol=zeros(1,3)+NaN;
    rmed=zeros(1,3)+NaN;
    rstd=zeros(1,3)+NaN;
    sphere=NaN;
    flxdn=zeros(1,4)+NaN;
    flxup=zeros(1,4)+NaN;
    brdf=zeros(1,4)+NaN;   %添加brdf
    theta=NaN;
    u0=NaN;
    soldst=NaN;
    iw=0;
    jw=0;
    kw=0;
%========================================================    
    file=fname(id).name;
    fid=fopen([fpath file],'r');
    while (feof(fid)==0);
        tline=fgetl(fid);
%         if(isempty(strfind(tline,'Residual after'))==0 && length(tline) > 30);
%             disp(tline);
%             skyerr=str2num(tline(1:12));
%         end;
        
        if(strcmp(tline,'   corse )'));
            iw=iw+1;
%             disp(tline);
            tline=fgetl(fid);
            tmp=str2num(tline);
            ext(iw,1)=tmp(1);
            ext(iw,2)=tmp(2);
            ext(iw,3)=tmp(3);
            ssa(iw,1)=tmp(4);
            ssa(iw,2)=tmp(5);
            ssa(iw,3)=tmp(6);
        end
        
        if(isempty(strfind(tline,' Phase function: ( angle       total       fine      corse )'))==0 && length(tline) >30);
%             disp(tline);
            jw=jw+1;
            for i=1:83;
                tline=fgetl(fid);
                tmp=str2num(tline);
                ang(i)=tmp(1);
                phase(i,jw,1)=tmp(2);
                phase(i,jw,2)=tmp(3);
                phase(i,jw,3)=tmp(4);
            end;
        end;
        
        if(isempty(strfind(tline,'Sun error'))==0 && length(tline) > 20);
            sunerr=str2num(tline(12:end));
%             disp(tline);
        end;
        
       
        if(isempty(strfind(tline,'Sky error'))==0 && length(tline) > 20);
            skyerr=str2num(tline(12:25));
%             disp(tline);
        end;
        
        if(isempty(strfind(tline,'r           min          max          er           eb           erb'))==0 && length(tline) > 30);
%             disp(tline);
            for i=1:4;
                tline=fgetl(fid);
                tmp=str2num(tline);
                rfre(i,1)=tmp(2);
                rfre(i,2)=tmp(8);
            end
        end
        
        if(isempty(strfind(tline,'Radius(micron)             psd'))==0 && length(tline) > 30);
%             disp(tline);
            fgetl(fid);
            fgetl(fid);
            fgetl(fid);
            for i=1:22;
                tline=fgetl(fid);
                tmp=str2num(tline(1:37));
                r(i)=tmp(1);
                dv(i)=tmp(2);
            end;
        end;
        
        if(isempty(strfind(tline,'Aerosol extinction optical'))==0 && length(tline) > 30);
%             disp(tline);
            fgetl(fid);
            fgetl(fid);
            fgetl(fid);
            for i=1:4;
                tline=fgetl(fid);
                tmp=str2num(tline);
                aod(i)=tmp(2);
            end
        end
        
        if(isempty(strfind(tline,'Aerosol absorption optical'))==0 && length(tline) > 30);
%             disp(tline);
            fgetl(fid);
            fgetl(fid);
            fgetl(fid);
            fgetl(fid);
            for i=1:4;
                tline=fgetl(fid);
                tmp=str2num(tline);
                aaod(i)=tmp(2);
            end
        end
       

        if(isempty(strfind(tline,'Effective Radius'))==0 && length(tline) > 15);
%             disp(tline);
            fgetl(fid);
            fgetl(fid);
            for i=1:3;
                tline=fgetl(fid);
                tmp=str2num(tline(9:end));
                reff(i)=tmp;
            end
        end
        
        if(isempty(strfind(tline,'Volume Median'))==0 && length(tline) > 15);
%             disp(tline);
            fgetl(fid);
            fgetl(fid);
            for i=1:3;
                tline=fgetl(fid);
                tmp=str2num(tline(9:end));
                rmed(i)=tmp;
            end
        end
        
        if(isempty(strfind(tline,'Standard Deviation'))==0 && length(tline) > 15);
%             disp(tline);
            fgetl(fid);
            fgetl(fid);
            for i=1:3;
                tline=fgetl(fid);
                tmp=str2num(tline(9:end));
                rstd(i)=tmp;
            end
        end
   
        if(isempty(strfind(tline,'Volume concentration'))==0 && length(tline) > 15);
%             disp(tline);
            fgetl(fid);
            fgetl(fid);
            for i=1:3;
                tline=fgetl(fid);
                tmp=str2num(tline(9:end));
                vol(i)=tmp;
            end
        end      
        
        if(isempty(strfind(tline,'Sky Radiances'))==0 && length(tline) > 10);%calculate the number of sky observation angle
 %           disp(tline)
            for i=1:4;
            fgetl(fid);
            end;
            nskyrad=0;
            tline=fgetl(fid);
           % disp(tline);
           for i=1:30;
                tline=fgetl(fid);
                nskyrad=nskyrad+1; %disp(nskyrad);
                if(strcmp(tline,'Wavelength  0.674') );
                break;
                end;
            end;
            nskyrad=nskyrad-1;
        end;
        
        if(isempty(strfind(tline,'Sphericity Parameter'))==0 && length(tline) > 15);
%             disp(tline);
            fgetl(fid);
            tline=fgetl(fid);
            tmp=str2num(tline);
            sphere=tmp(1);
        end        
        
        if(isempty(strfind(tline,'(km)  (W/m2)   (W/m2)'))==0 && length(tline) > 15);
%             disp(tline);
            tline=fgetl(fid);
            tmp=str2num(tline);
            flxdn(1)=tmp(2);%flux-down-BOT
            flxup(1)=tmp(3);%flux-up-BOT

            tline=fgetl(fid);
            tmp=str2num(tline);
            flxdn(2)=tmp(2);%flux-down-TOA
            flxup(2)=tmp(3);%flux-up-TOA
            
%z            for i=1:3;
%z                fgetl(fid);
%z            end;
%添加brdf  
             tline=fgetl(fid);
             tmp=str2num(tline);         %z  disp(tline);
             brdf=tmp;
             
             fgetl(fid);
             fgetl(fid);
            
            tline=fgetl(fid);
            tmp=str2num(tline);
            flxdn(3)=tmp(2);%radiance-forcing-BOT
            flxdn(4)=tmp(3);%radiance-forcing-efficency-BOT
            
            tline=fgetl(fid);
            tmp=str2num(tline);
            flxup(3)=tmp(2);%radiance-forcing-TOA
            flxup(4)=tmp(3);%radiance-forcing-efficency-TOA
            
        end        
    end; %do while
    fclose(fid);
    if(nansum(aod)>0 && sunerr <=0.016 && skyerr <= 15 ); % sun err and sky err should meet specified requirements
          yy=str2num(file(end-16:end-15))+2000;
        mm=str2num(file(end-14:end-13));
        dd=str2num(file(end-12:end-11));
        hh=str2num(file(end-9:end-8));
        mn=str2num(file(end-7:end-6));
        ss=str2num(file(end-5:end-4));
        %[theta,u0,soldst]=sunpos(yy,mm,dd,hh,mn,ss,stns_lat,stns_lon);
        theta=sunpos(yy,mm,dd,hh,mn,ss,stns_lat,stns_lon);
        ae440_675=log(aod(1)/aod(2))/log(675/440);
        aae440_675=log(aaod(1)/aaod(2))/log(675/440);
        ae440_870=log(aod(1)/aod(3))/log(870/440);
        aae440_870=log(aaod(1)/aaod(3))/log(870/440);
        aod550=aod(1)*(440/550)^ae440_675;
        aaod550=aaod(1)*(440/550)^aae440_675;
        ssa550=1-(aaod550/aod550);
        
        if(aod(1) < 0.4);
            ssa=zeros(4,3)+NaN;
            ssa550=NaN;
            rfre=zeros(4,2)+NaN;
            aae440_870=NaN;
        end;
       
       
%         fprintf(fidw,'%4i,%4i,%4i,%4i,%4i,%4i,',yy,mm,dd,hh,mn,ss);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',aod);
%         fprintf(fidw,'%10.4f,',aod550);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',ext(:,1));
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',ext(:,2));
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',ext(:,3));
%         fprintf(fidw,'%10.4f,',ae440_870);
% 
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',ssa(:,1));
%         fprintf(fidw,'%10.4f,',ssa550);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',ssa(:,2));
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',ssa(:,3));
%         
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',aaod);
%         fprintf(fidw,'%10.4f,',aaod550);
%         fprintf(fidw,'%10.4f,',aae440_870);
% 
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',rfre(:,1));
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',rfre(:,2));
% 
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,%10.4f,',dv);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,',reff);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,',vol);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,',rmed);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,',rstd);
% 
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',flxdn); %flux-down-BOT%flux-down-TOA%radiance-forcing-BOT%radiance-forcing-efficency-BOT
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',flxup);%flux-up-BOT%flux-up-TOA%radiance-forcing-TOA%radiance-forcing-efficency-TOA
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,',sphere,sunerr,skyerr);
%         fprintf(fidw,'%10.4f,%10.4f,%10.4f,%10.4f,',brdf);
%         %fprintf(fidw,'%10.4f,%10.5f,%10.4f,',theta,u0,soldst);%solar_zenith_angle,cosine of solar zenith angle for date and time,distance to sun in A.U. & diameter in degs
%         fprintf(fidw,'%10.4f',theta);%solar_zenith_angle
%         fprintf(fidw,'\n');
        
        daily_inversion=[yy,mm,dd,hh,mn,ss,aod,aod550,ext(:,1)',ext(:,2)',ext(:,3)',ae440_870,ssa(:,1)',ssa550,ssa(:,2)',ssa(:,3)',aaod,aaod550,aae440_870,rfre(:,1)',rfre(:,2)',dv,reff,vol,rmed,rstd,flxdn,flxup,sphere,sunerr,skyerr,brdf,theta,nskyrad];
        stats_inversion=[stats_inversion;daily_inversion];
    end;
end;

%=================================
%sort data by time;
stats_inversion=sorttime(stats_inversion);

for id=1:length(stats_inversion(:,1));
    fprintf(fidw,'%4i, %2i, %2i, %2i, %2i, %2i,',stats_inversion(id,1:6));
    for ipar=7:length(stats_inversion(1,:))-1;
        fprintf(fidw,'%10.4f,',stats_inversion(id,ipar));
    end;
    fprintf(fidw,'%4i,',stats_inversion(id,end));
    fprintf(fidw,'\n');
end;
fclose(fidw);
%-----------------------caculate solar-zenith-angle---------------------------------------------
function theta=sunpos(yr,mon,dy,hour,mn,sc,lat,long)
    

	jd=calc_jd(yr,mon,dy);   %day number in the year
      
	tz=0.0;	
	tm=((tz+hour)*3600+ mn*60+sc)/3600;
	[az,el,ha,dec,soldst]=sunae(yr,jd,tm,lat,long);

	
    pi=2.0*acos(0.0);
    a=lat*pi/180.0;
    b=dec*pi/180.0;
    c=ha*pi/180.0;

	theta=acos(sin(a)*sin(b) + cos(a)*cos(b)*cos(c))*180/pi;
	
    u0=sin(a)*sin(b) + cos(a)*cos(b)*cos(c);
    
    function jd=calc_jd(yr,mon,dy)
        month_day1=[31,28,31,30,31,30,31,31,30,31,30,31];
        month_day2=[31,29,31,30,31,30,31,31,30,31,30,31];
        year_day=0;
        if mon==1;
            jd=dy;
        elseif mon==2;
           jd=31+dy;
        else
           if(mod(yr,100)==0.0 && mod(yr,400)~=0.0) 
             for i=1:(mon-1);
                year_day=year_day+month_day2(i);
             end;
             jd=year_day+dy;
           else;
              for i=1:(mon-1);
                year_day=year_day+month_day1(i);
              end;
              jd=year_day+dy; 
           end
        end;
    
%---------------------------------------------------------------------+
%                                                                     |
%   function sunae
%                                                                     |
%   this subroutine calculates the local azimuth and elevation of the |
%     sun at a specific location and time using an approximation to   |
%     equations used to generate tables in The Astronomical Almanac.  |
%     refraction correction is added so sun position is apparent one. |
%                                                                     |
%   The Astronomical Almanac, U.S. Gov't Printing Office, Washington, |
%     D.C. (1985).                                                    |
%                                                                     |
%   input parameters                                                  |
%     year=year, e.g., 1986                                           |
%     day=day of year, e.g., feb 1=32                                 |
%     hour=hours plus fraction in UT, e.g., 8:30 am eastern daylight  |
%       time is equal to 8.5 + 5(5 hours west of Greenwich) -1(for    |
%       daylight savings time correction)                             |
%     lat=latitude in degrees (north is positive)                     |
%     long=longitude in degrees (east is positive)                    |
%                                                                     |
%   output parameters                                                 |
%     a=sun azimuth angle (measured east from north, 0 to 360 degs)   |
%     e=sun elevation angle (degs)                                    |
%     plus others, but note the units indicated before return         |
%                                                                     |
%---------------------------------------------------------------------+

function [az,el,ha,dec,soldst]=sunae(year,day,hour,lat,long)

twopi=6.2831853;
pi=3.1415927;
rad=0.017453293;
	  
%   get the current julian date (actually add 2,400,000 for jd)
delta=year-1949;
leap=floor(delta/4);
jd=32916.5+delta*365.0+leap+day+hour/24;

%   1st no. is mid. 0 jan 1949 minus 2.4e6; leap=leap days since 1949
%  the last yr of century is not leap yr unless divisible by 400
if(mod(year,100)==0.0 && mod(year,400)~=0.0) 
   jd=jd-1;
end

%   calculate ecliptic coordinates
time=jd-51545.0;
%   51545.0 + 2.4e6 = noon 1 jan 2000

%   force mean longitude between 0 and 360 degs
mnlong=280.460+0.9856474*time;
mnlong=mod(mnlong,360);
if(mnlong < 0) 
   mnlong=mnlong+360;
end

%   mean anomaly in radians between 0 and 2*pi
mnanom=357.528+0.9856003*time;
mnanom=mod(mnanom,360);
if(mnanom < 0) 
   mnanom=mnanom+360;
end
mnanom=mnanom*rad;

%   compute the ecliptic longitude and obliquity of ecliptic in radians
eclong=mnlong+1.915*sin(mnanom)+0.020*sin(2.*mnanom);
eclong=mod(eclong,360);
if (eclong < 0) 
   eclong=eclong+360;
end
oblqec=23.439-0.0000004*time;
eclong=eclong*rad;
oblqec=oblqec*rad;

%   calculate right ascension and declination
num=cos(oblqec)*sin(eclong);
den=cos(eclong);
ra=atan(num/den);
%   force ra between 0 and 2*pi
if (den < 0) 
   ra=ra+pi;
end
if (num < 0) 
   ra=ra+twopi;
end
         
%   dec in radians
dec=asin(sin(oblqec)*sin(eclong));
           
%   calculate Greenwich mean sidereal time in hours
gmst=6.697375+0.0657098242*time+hour; 
%   hour not changed to sidereal time since 'time' includes
%   the fractional day 
gmst=mod(gmst,24);
if (gmst < 0) 
   gmst=gmst+24;
end

%   calculate local mean sidereal time in radians 
lmst=gmst+long/15;
lmst=mod(lmst,24);
if(lmst < 0) 
    lmst=lmst+24;
end
lmst=lmst*15*rad;

%   calculate hour angle in radians between -pi and pi
ha=lmst-ra;
if(ha < (-1*pi)) 
   ha=ha+twopi;
end
if(ha > pi) 
   ha=ha-twopi;
end
      
%   change latitude to radians
lat=lat*rad;
	
%   calculate azimuth and elevation
el=asin(sin(dec)*sin(lat)+cos(dec)*cos(lat)*cos(ha));
az=asin(-1*cos(dec)*sin(ha)/cos(el));
      
%   this puts azimuth between 0 and 2*pi radians
if(sin(dec)-sin(el)*sin(lat) > 0) 
   if(sin(az) < 0) 
      az=az+twopi;
   end
else
   az=pi-az;
end
%   if az=90 degs, elcritical=asin(sin(dec)/sin(lat))
%    elc=asin(sin(dec)/sin(lat))
%    if(el.ge.elc)az=pi-az
%    if(el.le.elc.and.ha.gt.0.)az=twopi+az

%   calculate refraction correction for US stan. atmosphere
%   need to have el in degs before calculating correction
el=el/rad;
      
if(el > 19.225)  
   refrac=.00452*3.51823/tan(el*rad);
elseif (el > -0.766 && el < 19.225) 
   refrac=3.51823*(0.1594+0.0196*el+0.00002*el^2)/(1+0.505*el+0.0845*el^2);
else
   refrac=0.0;
end

%   note that 3.51823=1013.25 mb/288 C
el=el+refrac;
%   elevation in degs
       
%   calculate distance to sun in A.U. & diameter in degs
soldst=1.00014-0.01671*cos(mnanom)-0.00014*cos(2.*mnanom);
soldia=0.5332/soldst;
      
%   convert az and lat to degs before returning
az=az/rad;
lat=lat/rad;
ha=ha/rad;
dec=dec/rad;

%   mnlong in degs, gmst in hours, jd in days if 2.4e6 added;
%   mnanom,eclong,oblqec,ra,and lmst in radian
  function data=sorttime(data)
        data2=data;
        n=length(data2(1,:));
        data2(:,n+1)=datenum(data2(:,1:6));
        data2=sortrows(data2,n+1);
        data=data2(:,1:n);
        



t=ones(1,10)*2
T={[1,2,3];[4,5,6,7,8]};
length(T)
for index=1:length(T) 
    a=0;
    sum(T{index})
    for i=T{index}
        a=a+i;
    end
    a
        
end

str2num(strrep('04:55',':',''))

t1={'1:2:44';'1:18:35';'5:19:29'};
d=datetime(t1,'InputFormat','hh:mm:ss');
d

ts={{'1:2:44';'1:18:35';'5:19:29'};{'1:4:1';'1:19:25';'3:19:37';'5:20:41';'6:19:5';'7:18:56';'7:39:18'}};
ds=cell(1,2);
for t=length(ts)
    ds{t}=datetime(ts{t},'InputFormat','hh:mm:ss');
    ds{t}
end
ds
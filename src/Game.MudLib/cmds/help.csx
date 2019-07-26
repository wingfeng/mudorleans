int main(object me, string arg)
{
    
    return notify_fail("没有针对这项主题的说明文件。\n");
}
int help(object me)
{
    write(@"
指令格式：help < 主题 > 例如：> help map
这个指令提供你针对某一主题的详细说明文件，若是不指定主题，则提供你有关
主题的文件。
"
    );
    return 1;
}
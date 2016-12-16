## Coding部分



创建一个公钥：（密码可选）

```
$ssh-keygen -t rsa -b 4096 -C "your_email@example.com"
```

会在`C:\Users\liang\.ssh` 目录生成`id_rsa.pub` 文件，拷贝文件内容，添加公钥到Coding上。

测试公钥是否生效：（git@git.coding.net 不可更改）

```
$ssh -T git@git.coding.net
```

 ## Hexo安装

安装命令(bolg 是项目名)：

```
npm install hexo-cli -g
hexo init blog
cd blog
npm install
hexo server
```

## Hexo配置

在一开始hexo生成的blog目录下面找到_config.yml
在文件最低端加上deploy到coding的配置

```
deploy:
  type: git
  repo:
    coding: git@git.coding.net:username/projectname.git,coding-pages
```

注意coding的配置是 coding:{项目git地址},{branch}

安装Deploy git模块：

```
npm install hexo-deployer-git --save
```

## 推送

```
hexo deployer
```

或

```
hexo d&&hexo g
```

##  域名

如果样式没有正确显示，请绑定域名。
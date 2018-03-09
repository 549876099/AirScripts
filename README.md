# AirScripts

![AppVeyor](https://img.shields.io/appveyor/ci/gruntjs/grunt.svg)
![version](https://img.shields.io/badge/version-1.0-brightgreen.svg)
[![Github All Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/549876099/AirScripts/releases)
![Mozilla Add-on](https://img.shields.io/amo/stars/dustman.svg)

# 一个远程脚本执行工具

## 功能
* 远程执行系统命令(关机、重启、注销、睡眠、休眠、锁屏)
* 远程执行bat脚本文件（存放于根目录下，Scripts目录中）

## 下载
下载[最新版本](https://github.com/shadowsocks/shadowsocks-windows/releases"V1.0")

## 要求
[Microsoft .NET Framework 4.6.1](https://www.microsoft.com/zh-cn/download/details.aspx?id=49982) 或更高

[Microsoft Visual C++ 2015 Redistributable](https://www.microsoft.com/en-us/download/details.aspx?id=53840) (x86)

## 网络接口

### 地址
> http://IP_Address:port/api

### 调用方法
> POST或GET

### 请求参数
| 是否必选 |   参数名   |  类型  |   参数说明   |
|:--------:|:----------:|:------:|:------------:|
|    是    |   action   | string | 执行动作类型(system或shell) |
|    是    |  command   | string |   执行命令   |
|    否    | secret_key | string |     密钥     |

#### 执行的动作为system时的执行命令

| 参数值    | 执行命令 |
| --------- | -------- |
| shutdown  | 关机     |
| reboot    | 重启     |
| logoff    | 注销     |
| sleep     | 睡眠     |
| hibernate | 休眠     |
| lock      | 锁屏     |

#### 执行的动作为shell时的执行命令
执行主程序目录下，Scripts目录中的脚本文件。

command参数引入脚本文件文件名即可

### 请求示例
> http://192.168.0.10:8000/api?action=system&command=lock

> http://192.168.0.10:8000/api?action=shell&command=notepad&secret_key=123456

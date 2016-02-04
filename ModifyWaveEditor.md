# 简介 #
修改Nero WaveEditor以便我们能够使用F2键插入时间。

# 详细内容 #
## 准备材料 ##
  1. Resource Hacker
  1. 已经安装的WaveEdit中文包

## 步骤 ##
  1. 确保WaveEdit不在运行
  1. 运行ResHacker，打开WaveEditor安装目录下的 **waveedit-chs.nls** 文件
  1. 左侧找 **加速器** (Accelarator)，展开到底，会发现右边有许多代码。
  1. 找到下列代码
```
	VK_F1, 57669, NOINVERT, SHIFT, VIRTKEY
```
  1. 在以上代码后另起一行，整行插入下列代码：
```
	VK_F2, 32807, NOINVERT, VIRTKEY
```
  1. 编译脚本，保存，退出。

## 效果 ##
采用F2作为快捷键。如果你喜欢其它快捷键，可以更改VK\_F2为其它值。具体可以参照其它代码。
## 行内元素与块级元素  
行内元素：和其他元素都在一行，无法设置宽高，宽高由内部字体内容确定，如span、img、inpput...  
块级元素：独占一行，可以设置宽高，如div、from、p、ul、h1~h6...  
使用display属性对两者进行转换  
display:inline 转为行内元素  
display:block 转为块级元素  
display:inline-block 转为行内块级元素  

## line-height与height的区别  
height指的就是元素的高度  
line-height指的是元素中每一行文字的高度，只要换行整个盒子模型的高度就会被撑大  

## css优先级比较  
!importment>内联样式>id>class>标签>通配  



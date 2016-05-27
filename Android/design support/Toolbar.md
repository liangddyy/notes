



## 问题

> Android toolbar设置标题无效？

toolbar.setTitle()需要在调用setSupportActionBar(toolbar)方法之前设置

> 如何添加返回箭头？

```
setSupportActionBar(toolbarInfo);
//设置是否有返回箭头
getSupportActionBar().setDisplayHomeAsUpEnabled(true);
```

添加返回事件

```
@Override
public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
        case android.R.id.home:
            finish();
            return true;
    }
    return super.onOptionsItemSelected(item);
}
```


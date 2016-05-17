# Android动画——ViewPager

ViewPager能自动实现屏幕滑动动画。屏幕划动是在两个完整界面间的转换，它在一些UI中很常见，比如设置向导和幻灯放映。ViewPager常用于制作APP的向导。

 ![ViewPager](ViewPager.gif)

## 示例：

.xml

 ```
<android.support.v4.view.ViewPager
        android:id="@+id/vp_guide"
        android:layout_width="match_parent"
        android:layout_height="match_parent"></android.support.v4.view.ViewPager>
 ```

.java(onCreate)

```
ViewPager mViewPager = (ViewPager) findViewById(R.id.vp_guide);
mViewPager.setAdapter(new GuideAdapter());
```

## 禁用滑动

有时我们使用 ViewPager 只需要按键触发而并不需要滑动。这时只需要写一个类继承 ViewPager 并 重写 onTouchEvent() 方法，什么都不做。如：

```
@Override
public boolean onTouchEvent(MotionEvent ev) {
	
	return true;
}
```


**自定义Gradle代码**如下:

```
repositories {
    flatDir {
        dirs 'libs'
    }
}

dependencies {
    //================================================================================
    // 批量导入 libs 里的所有 .aar 类库.
    //================================================================================
    def batchImportAar = {
        fileTree(dir: 'libs', include: '*.aar').each { File file ->
            def name = file.name.lastIndexOf('.').with { it != -1 ? file.name[0..<it] : file.name };
            compile(name: name, ext: 'aar')
            //在内部类外时,可用以下等价形式.
            //dependencies.add("compile", [name: name, ext: 'aar'])
        }
    }
    batchImportAar()
    //================================================================================
    // 批量导入 libs 里的所有 .jar 类库.
    //================================================================================
    compile fileTree(dir: 'libs', include: ['*.jar'])
    //================================================================================
    // 正确引用自定义类库
    //================================================================================
    def compileLibrary = { name ->
        //鉴于某些类库同样引用了.aar类库,所以必须把所在路径也添加到当前项目的flatDir
        //否则会出现无法正确解析识别其引用的 .aar 类库.
        repositories.flatDir.dirs(project(name).file('libs'))
        //因为Studio本身的缺陷,导致无法正确处理 debug,release,导致引用的类库无法区分
        //是否为调试模式.所以需要同时添加两条配置,并结合类库自身的相关设置,方能解决.
        debugCompile project(path: name, configuration: 'debug')
        releaseCompile project(path: name, configuration: 'release')
    }
    compileLibrary(':EasyAndroid')
    compileLibrary(':DataSync_Android')
    compileLibrary(':EasyAndroid_QrCodeScan')
    compileLibrary(':EasyAndroid_Printer')
    compileLibrary(':EasyAndroid_OpenCamera')
    compileLibrary(':EasyAndroid_GifImageView')
    compileLibrary(':EasyAndroid_Downloader')
}
```
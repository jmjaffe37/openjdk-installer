; This file default contains translations for all "unofficial" translation text in the resulting EXE installer.
; Note: here, "unofficial" refers to translations that are translated by inno setup but have a few messages missing.
; [Languages]: contains the list of languages we support. Inno Setup uses the compiler to translate default installer text.
; [CustomMessages]: contains the list of translations for the custom tasks that the user can select during installation.

[Languages]
; Note: ChineseTW and ChineseCN still need translations for certain progress-bar screen messages
Name: "ChineseTW";  MessagesFile: "compiler:Languages\Unofficial\ChineseTraditional.isl"
Name: "ChineseCN";  MessagesFile: "compiler:Languages\Unofficial\ChineseSimplified.isl"


[CustomMessages]
; Notes:
; 1) All translations in the initial PR were pulled directly from the wix MSI installer translation files (Jul 2025)
; 2) Any missing translations will default to English
; 3) When testing translations, the `Yes` and `No` buttons will always be in the language of the user's machine (regardless of the selected language in the installer)
; 4) All commented out translations were made by AI and need to be verified before using/uncommenting
; 5) Translation entries allow us to have input arguments. They are specified as %1, %2, etc.

; For a list of default custom messages (Translated by Inno Setup), see: https://jrsoftware.org/ishelp/index.php?topic=custommessagessection
; Example: we are using AssocFileExtension from this list

; Custom task descriptions
ChineseCN.FeatureEnvironmentDesc=通过将 JDK 安装路径添加到 PATH 值开头来修改 PATH 环境变量值.
ChineseCN.FeatureJavaHomeDesc=使用 JDK 安装路径来设置或重写 JAVA_HOME 环境变量值.
; ChineseCN.FeatureOracleJavaSoftDesc=覆盖 Oracle 的注册表项 HKLM\Software\JavaSoft。卸载 %1 后，需要重新安装 Oracle Java 以重新创建这些注册表项。
ChineseCN.FeatureEnvironmentTitle=修改 PATH 变量值.
ChineseCN.FeatureJavaHomeTitle=设置或重写 JAVA_HOME 变量.
; ChineseCN.FeatureJarFileRunWithTitle=关联 .jar
; ChineseCN.FeatureOracleJavaSoftTitle=JavaSoft (Oracle) 注册表项

ChineseTW.FeatureEnvironmentDesc=將 JDK 安裝路徑新增至 PATH 值開頭來修改 PATH 環境變數值.
ChineseTW.FeatureJavaHomeDesc=使用 JDK 安裝路徑來設定或重寫 JAVA_HOME 環境變數值.
; ChineseTW.FeatureOracleJavaSoftDesc=覆寫 Oracle 的登錄機碼 HKLM\Software\JavaSoft。解除安裝 %1 後，需要重新安裝 Oracle Java 以重新建立這些登錄機碼。
ChineseTW.FeatureEnvironmentTitle=修改 PATH 變數值
ChineseTW.FeatureJavaHomeTitle=設定或重寫 JAVA_HOME 變量
; ChineseTW.FeatureJarFileRunWithTitle=關聯 .jar
; ChineseTW.FeatureOracleJavaSoftTitle=JavaSoft (Oracle) 登錄機碼

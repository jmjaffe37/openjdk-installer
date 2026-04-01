; This file contains translations for all text in the resulting EXE installer.
; [Languages]: contains the list of languages we support. Inno Setup uses the compiler to translate default installer text.
; [CustomMessages]: contains the list of translations for the custom tasks that the user can select during installation.

[Languages]
Name: "English";    MessagesFile: "compiler:Default.isl"
Name: "German";     MessagesFile: "compiler:Languages\German.isl"
Name: "Spanish";    MessagesFile: "compiler:Languages\Spanish.isl"
Name: "French";     MessagesFile: "compiler:Languages\French.isl"
Name: "Japanese";   MessagesFile: "compiler:Languages\Japanese.isl"

[CustomMessages]
; Notes:
; 1) All translations in the initial PR were pulled directly from the wix MSI installer translation files (Jul 2025)
; 2) Any missing translations will default to English
; 3) When testing translations, the `Yes` and `No` buttons will always be in the language of the user's machine (regardless of the selected language in the installer)
; 4) All commented out translations were made by AI and need to be verified before using/uncommenting
; 5) Translation entries allow us to have input arguments. They are specified as %1, %2, etc.

; For a list of default custom messages (Translated by Inno Setup), see: https://jrsoftware.org/ishelp/index.php?topic=custommessagessection
; Example: we are using AssocFileExtension from this list

; Custom task descriptions - English (default)
FeatureEnvironmentDesc=Modify PATH environment variable by prepending the JDK installation directory to the beginning of PATH.
FeatureJavaHomeDesc=Sets or overrides JAVA_HOME environment variable with the JDK installation directory.
FeatureOracleJavaSoftDesc=Overwrites Oracle's reg key HKLM\Software\JavaSoft. After uninstallation of %1, Oracle Java needs to be reinstalled to re-create these registry keys.
FeatureEnvironmentTitle=Modify PATH variable
FeatureJavaHomeTitle=Set or override JAVA_HOME variable
FeatureJarFileRunWithTitle=Associate .jar
FeatureOracleJavaSoftTitle=JavaSoft (Oracle) registry keys

German.FeatureEnvironmentDesc=In die PATH-Umgebungsvariable einfügen.
German.FeatureJavaHomeDesc=Als JAVA_HOME-Umgebungsvariable verwenden.
; German.FeatureOracleJavaSoftDesc=Überschreibt Oracles Registrierungsschlüssel HKLM\Software\JavaSoft. Nach der Deinstallation von %1 muss Oracle Java neu installiert werden, um diese Registrierungsschlüssel wiederherzustellen.
German.FeatureEnvironmentTitle=Zum PATH hinzufügen
German.FeatureJavaHomeTitle=JAVA_HOME-Variable konfigurieren
; German.FeatureJarFileRunWithTitle=.jar-Datei verknüpfen
; German.FeatureOracleJavaSoftTitle=JavaSoft (Oracle) Registrierungsschlüssel

Spanish.FeatureEnvironmentDesc=Añadir a la variable de entorno PATH.
Spanish.FeatureJavaHomeDesc=Establecer la variable de entorno JAVA_HOME.
Spanish.FeatureOracleJavaSoftDesc=Sobrescribir las claves de registro HKLM\Software\JavaSoft (Oracle). Si se desinstala %1, la ejecución de Oracle Java desde la ruta "C:\Program Files (x86)\Common Files\Oracle\Java\javapath" no funcionará. Será necesario reinstalarlo.
Spanish.FeatureEnvironmentTitle=Añadir al PATH
Spanish.FeatureJavaHomeTitle=Establecer la variable JAVA_HOME
Spanish.FeatureJarFileRunWithTitle=Asociar .jar
Spanish.FeatureOracleJavaSoftTitle=Claves de registro JavaSoft (Oracle)

French.FeatureEnvironmentDesc=Ajouter à la variable d'environnement PATH.
French.FeatureJavaHomeDesc=Définir la variable d'environnement JAVA_HOME.
French.FeatureOracleJavaSoftDesc=Écrase les clés de registre HKLM\Software\JavaSoft (Oracle). Après la désinstallation d'%1, Oracle Java lancé depuis le PATH "C:\Program Files (x86)\Common Files\Oracle\Java\javapath" ne fonctionne plus. Réinstaller Oracle Java si besoin
French.FeatureEnvironmentTitle=Ajouter au PATH
French.FeatureJavaHomeTitle=Définir la variable JAVA_HOME
French.FeatureJarFileRunWithTitle=Associer les .jar
French.FeatureOracleJavaSoftTitle=Clés de registre JavaSoft (Oracle)

; Japanese.FeatureEnvironmentDesc=JDKインストールディレクトリをPATHの先頭に追加してPATH環境変数を変更します。
; Japanese.FeatureJavaHomeDesc=JDKインストールディレクトリでJAVA_HOME環境変数を設定または上書きします。
; Japanese.FeatureOracleJavaSoftDesc=OracleのレジストリキーHKLM\Software\JavaSoftを上書きします。%1のアンインストール後、これらのレジストリキーを再作成するにはOracle Javaの再インストールが必要です。
; Japanese.FeatureEnvironmentTitle=PATH変数を変更
; Japanese.FeatureJavaHomeTitle=JAVA_HOME変数を設定または上書き
; Japanese.FeatureJarFileRunWithTitle=.jarを関連付け
; Japanese.FeatureOracleJavaSoftTitle=JavaSoft (Oracle) レジストリキー
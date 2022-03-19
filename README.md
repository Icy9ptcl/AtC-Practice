# AtCoder で取り組んだ問題を保存するところ

です。

# おまけ: 環境構築をちょっと楽にする PowerShell スクリプト

``Config`` フォルダ内にいろいろ入っています。

- ``Config/start.ps1``
  - コンテスト用のフォルダを作成する指示を出すスクリプトです。
    ``atcoder-cli new <名前>`` を実行したり、エクスプローラーやVSCodeを開いたりします。
- ``Config/csharp/init.ps1``
  - 問題ごとに C# のコンソールアプリのプロジェクトを作るやつです。
  - AtCoder にコードをコピーして提出できるように、``Config/csharp/data/Program.cs`` をコピーして名前空間を自動的に指定します。たとえば ``abc123_a`` とか。
  - 実行したいコードを書くだけでよくなります。``static void Main`` とかをタイプしなくてよくなりますが、実戦のときに思い出せるようにしてください。
- ``Config/csharp/data/Program.cs``
  - ``init.ps1`` が勝手にコピーするファイルです。
  - このコード内の ``<Project_Name>`` なるテキストは自動的に生成される名前で置き換えられます。たとえば ``abc123_a`` とか
- ``Config/csharp/package.json``
  - ``npm run`` で実行できる Task を追加します。
- ``Config/csharp/template.json``
  - atcoder-cli が、問題ごとにコピーしてくれるファイルの名前を指定します。
- ``Config/csharp/note.md``
  - この補助スクリプトの使い方どうするんだっけというときに参照するやつです。不要なら template.json から外してください。
- ``Config/csharp/.vscode/launch.json``
  - VSCode でコードの実行・テスト・提出をしやすくする、デバッグの「構成」です。
    デバッグ(初期設定では ``F5`` キー) からどうぞ。

## ☆参考

[AtCoder を C# で戦う環境を整える - .NET Core - OITA](https://oita.oika.me/2020/05/10/at-coder-csharp/) を参考にして作っています。
(もしよかったらこの記事に :star: をつけてください！)

## 導入

[コマンドラインツールatcoder-cliを公開しました - わたしろぐ](http://tatamo.81.la/blog/2018/12/07/atcoder-cli/)
[online-judge-tools/oj - GitHub](https://github.com/online-judge-tools/oj)
以上の2つを導入します (作者さんに感謝です :pray:)
それと [Visual Studio Code](https://code.visualstudio.com/) を用意してください。これ以外のエディタでもほとんどの機能が使えます。その場合 ``.vscode/launch.json`` は使えなくなってしまうので、適宜 ``npm run test`` などのようなコマンドを手打ちで実行してください。
導入には Node.js と Python3 が必要です。

```powershell
npm install -g atcoder-cli
pip3 install online-judge-tool
```

## 設定

atcoder-cli と online-judge-tools を設定します。
[atcoder-cli インストールガイド - わたしろぐ](http://tatamo.81.la/blog/2018/12/07/atcoder-cli-installation-guide/) と [online-judge-tools/oj/getting-started](https://github.com/online-judge-tools/oj/blob/master/docs/getting-started.ja.md) の手順をやっておきましょう。

少なくとも必要な手順は以下です

```powershell
acc login
oj login https://atcoder.jp
```

続いて補助用のファイルが入るフォルダを作成します。

```powershell
acc config-dir
```

から atcoder-cli が使う設定の場所を確認してください。
ここに、このリポジトリの ``Config/csharp`` をコピーします。``csharp`` なるフォルダをそのまま、 atcoder-cli のフォルダに入れます。

```powershell
acc config default-template csharp
```

``Config/csharp`` のフォルダができるはずです。

続いて、コンテスト用のフォルダを作成したい場所に ``Config/start.ps1`` を配置します。

たとえば `C:\Users\icy9ptcl\Documents\Atcoder-practice\start.ps1`
のように配置すると

```plaintext
C:\Users\icy9ptcl\Documents\
  Atcoder-practice/
  |-- start.ps1  <-- コンテスト用のフォルダを作るスクリプト
  |-- abc001  <-- コンテスト用のフォルダ
      |-- a/  <-- a 問題 
          |-- Program.cs  <-- a 問題のコード
      |-- b/ 
          |-- Program.cs
      |-- ...
  |-- abc002
  |-- ...
```

という感じにフォルダができます。

## 実行

### コンテストに参加する

AtCoderのコンテストページを開いてその略称を確認してください。``abc123`` とか。
start.ps1 を実行します。作業ディレクトリは start.ps1 と同じ場所で

```powershell
Type the name of AtCoder contest. // AtCoder のコンテスト名の略称を入れる
abc123

Contest name is: abc123
Is that okay? (y/n): y // 名前間違ってなければ y

...

Done! Choose a problem and open that folder with VSCode, and run 'Initialize' task to begin.
// Enter で閉じる
```

VSCode とエクスプローラーが開きます。解きたい問題を選んで、VSCode でそのフォルダを開いてください。
(例えば ``a`` 問題なら `abc123/a` を開く)

続いてターミナルを開いて (VSCodeなら ``Ctrl + @``)

```powershell
./init.ps1
```

を実行すると dotnet new console やらなんやらが実行されます。これ以降は F5 を押すとコードを実行できます。

コードテストや提出は、左ペインのデバッグから行うか、

```bash
// ふつうに実行
dotnet run
// コードテスト
npm run test 
// コードを提出
npm run submit 
```

などコンソールからも実行できます。 ``.vscode/launch.json`` をいじるとできることが増えます。

## 注意

この補助スクリプトやらは PowerShell や Markdown 始めたてで書いたものです。誤作動する可能性が否定できないので、バックアップはこまめにとってください。
関係ないファイルが消えたり、コードやファイルが稚拙すぎて体調を悪くされたりしても、作者は責任を負いません。

Windows Defender をお使いであれば「ランサムウェアの保護」から「コントロールされたフォルダーアクセス」を使うと誤作動したときに、関係ないファイルが消えずに済みます。

## 最後に

「これ追加するといいんじゃない？」「誤作動対策にはこうするといいよ」などアイデアあればどんどん Issue や Pull request を投げてください！学習させていただきます。

﻿# Capybara Translate Addin

Excelから機械翻訳APIとText-to-Speech APIを呼び出せるアドインです。主にAnkiカード作成を効率化するために開発しましたが、Ankiユーザー以外の方にも便利かもしれません。
機械翻訳APIについては、現在下記のサービスに対応しています。

- Google Cloud Translation API V2
- DeepL API
- OpenAI API (gpt-4)

Text-to-Speech APIについては、現在下記のサービスに対応しています。

- Google Text-to-Speech API V1

また、このアドインを使用するには、上記サービスのAPIキー (Googleについてはサービスアカウントキー) を事前に取得しておく必要があります。
APIキーおよびサービスアカウントキーを取得したら、アドインのSettingsダイアログに入力します。Settingsダイアログは、リボンのCapybara Translate Addinタブ > Preferences > Settingsをクリックすると表示されます。
各サービスのAPIキーを対応するフィールドに入力しOKボタンをクリックしてダイアログを閉じます。

# Capybara Translate Addin

https://github.com/capybara-translation/CapybaraTranslateAddin/assets/9638290/5706483b-d566-4044-9c57-e1c309eb5435

## Overview
Excelから機械翻訳APIとText-to-Speech APIを呼び出せるアドインです。主にAnkiカード作成を効率化するために開発しましたが、Ankiユーザー以外の方にも便利かもしれません。
機械翻訳APIについては、現在下記のサービスに対応しています。

- Google Cloud Translation API V2
- DeepL API
- OpenAI API (gpt-4)

Text-to-Speech APIについては、現在下記のサービスに対応しています。

- Google Text-to-Speech API V1

## How to use Capybara Translate Addin

[Releaseページ](https://github.com/capybara-translation/CapybaraTranslateAddin/releases)にインストーラーを公開していますので、そちらからダウンロードしてください。

また、このアドインを使用するには、上記サービスのAPIキー (Googleについてはサービスアカウントキー) を事前に取得しておく必要があります。
APIキーまたはサービスアカウントキーを取得したら、アドインのSettingsダイアログに入力します。Settingsダイアログは、リボンのCapybara Translate Addinタブ > Preferences > Settingsをクリックすると表示されます。
各サービスのAPIキーを対応するフィールドに入力しOKボタンをクリックしてダイアログを閉じます。


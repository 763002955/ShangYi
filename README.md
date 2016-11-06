# ShangYi App

## Layout

- 新闻资讯
  - Department Number List
  - 联系电话
    - Department
    - Phone Number
  - 新闻资讯
    - Article List
      - Thumbnail
      - Title
      - Content
      - Picture List
        - Index
        - Content
- 走进尚义
  - 尚义概况
    - Article List
  - 下马圈乡
    - Article List
    - 开放的
      - 区域优势（图文）
      - 行政村
    - 活跃的
      - 旅游生态（图片）
      - 美丽乡村（图片列表）
    - 希望的
      - 产业规划（图文）
- 旅游特色
  - Article List
- ~~本地特产~~
- 便民服务
  - Car-pooling List
  - 拼车服务
    - Time
    - From/To
    - Name
    - Phone Number
  - ~~火车票~~
  - 医疗保障
    - Article List
    - 列表
    - 外链
  - Hiring List
  - 招聘信息
    - Position
    - Details
    - Location
    - Salary
    - Phone Number
- 行政办公
  - Office Number List
  - 通讯录
    - Name
    - Job-title
    - Phone Number
  - Notification List
  - 通知公告
    - Title
    - Uploader
    - Timestamp
    - Content
    - Phone Number
  - Document List
  - 公文查阅
    - Title
    - Index
    - Content
    - Attachment
    - Uploader
    - Timestamp
- 左侧栏
  - 登录
    - Name
    - Password
    - Avatar
  - 注销
  - 软件更新
    - Version
    - Static File

## User Info

- Name
- Password
- Avatar

## App Info

- Version
- Static File

## Phone Number

- Department/Job-title
- Name (null or not null)
- Phone Number

## Category

- Parent ID
- ID
- Name
  - 新闻资讯
  - 尚义概况
  - 下马圈乡
  - ...
- Thumbnail
- IsLeaf

## Article

- Category ID
- Title
- Thumbnail Name
- Content
  - Text
  - Image Name
- Timestamp

## Blob

- File Name
- Content

## Car-pooling

- Time
- From
- To
- Name
- Phone Number

..
- UID
- Timestamp

## Hiring

- Position
- Details
- Location
- Salary
- Phone Number

..
- UID
- Timestamp

## Notification

- Title
- Uploader
- Content
- Phone Number

..
- UID
- Timestamp

## Document

- Title
- Index
- Content
  - Text
- Attachment Name
- Uploader

..
- UID
- Timestamp

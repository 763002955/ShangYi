# ShangYi App

## Layout

- ������Ѷ
  - Department Number List
  - ��ϵ�绰
    - Department
    - Phone Number
  - ������Ѷ
    - Article List
      - Thumbnail
      - Title
      - Content
      - Picture List
        - Index
        - Content
- �߽�����
  - ����ſ�
    - Article List
  - ����Ȧ��
    - Article List
    - ���ŵ�
      - �������ƣ�ͼ�ģ�
      - ������
    - ��Ծ��
      - ������̬��ͼƬ��
      - ������壨ͼƬ�б�
    - ϣ����
      - ��ҵ�滮��ͼ�ģ�
- ������ɫ
  - Article List
- ~~�����ز�~~
- �������
  - Car-pooling List
  - ƴ������
    - Time
    - From/To
    - Name
    - Phone Number
  - ~~��Ʊ~~
  - ҽ�Ʊ���
    - Article List
    - �б�
    - ����
  - Hiring List
  - ��Ƹ��Ϣ
    - Position
    - Details
    - Location
    - Salary
    - Phone Number
- �����칫
  - Office Number List
  - ͨѶ¼
    - Name
    - Job-title
    - Phone Number
  - Notification List
  - ֪ͨ����
    - Title
    - Uploader
    - Timestamp
    - Content
    - Phone Number
  - Document List
  - ���Ĳ���
    - Title
    - Index
    - Content
    - Attachment
    - Uploader
    - Timestamp
- �����
  - ��¼
    - Name
    - Password
    - Avatar
  - ע��
  - �������
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

## Article (Composite)

- Category
  - ������Ѷ
  - ����ſ�
  - ����Ȧ��
  - ...
- Sub-Category ID
- Thumbnail
- Title
- Content
  - Text
  - Image
- Timestamp

## Picture

- Index
- Content

## Car-pooling

- Time
- From
- To
- Name
- Phone Number
- UID
- Timestamp

## Hiring

- Position
- Details
- Location
- Salary
- Phone Number
- UID
- Timestamp

## Notification

- Title
- Uploader
- Timestamp
- Content
- Phone Number
- UID

## Document

- Title
- Index
- Content
- Attachment
- Uploader
- Timestamp
- UID

# WinForm04 Project 카드 게임 개발 2.3.3v
## 기능 설명
마법 카드의 종류는 공격력 증가 단일 카드 였지만 다양성을 위해 공격력 증가와 체력 증가로 나눔



- ## Form01
    - ### [마법카드 종류](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L59-L87)
        - 캐릭터 카드와 동일하게 카드 구조체에 이미지와 능력치를 대입한다.
    - ### [마법카드 추가](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L182-L200)
        - 마법카드는 공격력과 체력 2가지로 나뉘며, 0~9까지의 난수로 0~4: 공격력 5~9: 체력 50:50 비율로 선정 된다.  
    - ### [마법카드 사용](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L631-L650)
        - Magicbool 정수값 구별기로 공격력 카드인지 체력카드인지 중간 과정을 거쳐 각각의 소스 코드로 이동 된다. 


- ## 버그

## 버전 업데이트 지연
```
NA.NA.4v 업데이트 지연
    1.1.0v -> 1.1.1v
    - 마법 카드 사용시 캐릭터 카드에 사용하는 것이 아닌 필드에 소환되는 버그
    - 버리기 기능 사용시 카드가 없어도 없어 지는 버그

    2.1.0 -> 2.1.2v 
    - 마법 카드를 사용 할때 필드 소환의 버튼이 남아 있음.
      눌렀을 시 데이터의 변화는 없음
    - 버리기 기능을 켠 상태로 손 패의 버튼이나 필드의 pictureBox를 클릭시 버리기 버튼이 활성화 되지 않음.
    - 턴 종료 시 손패 버튼이나 필드의 pirtureBox를 클릭시 일부분 버튼이 활성화 됨.
    
    2.2.0v -> 2.2.3v
```
## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정

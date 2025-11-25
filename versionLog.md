# WinForm04 Project 카드 게임 개발 2.1.0v
## 기능 설명
마법 카드를 만들어 캐릭터 카드의 능력치를 올려주는 기능을 추가하여 카드의 다양화를 만듦.  
기능 테스트중 발견된 버그 수정.



- ## Form01
    - ### [마법 카드 생성](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L152-L247)
        - CardChoice 정수를 Random.Next()로 변화하여 0~9까지의 난수로 캐랙터 카드와   
        마법 카드의 확률를 구분 짓는다
        - 위에서 정해진 카드는 mycard 정수를 Random.Next()로 변화하여 0~9까지의 난수로 카드 구조체에서   
        알맞는 데이터를 손패 데이터로 옮긴다.
    - ### [마법 카드 사용](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L559-L607)
        - 캐릭터 카드 였을때 (필드 소환)문구를 가지고 있던 버튼을 (사용 하기)로 바꾸어 사용한다
        - 캐릭터 카드일때와 마법 카드일때의 소스코드를 구별하여 카드마다 다른 결과를 불러 오게 한다.
    - ### [buttonTrue_False](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L101=L108)
        - 손패 카드의 클릭여부를 초기화 시키는 함수
    - ### [Card_FieldFull_Fieldnull](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#109-L126)
        - 필드 카드의 캐릭터 카드가 있는지 없는지를 구별하는 함수
    - ### [MagicSpell_AddCard](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L128-L135)
        - 손패에 있는 마법카드를 선택 했을때 필드에 캐릭터 카드가 있는지 없는지 구별하는 함수 

- ## 버그
    - ### 마법카드 기능적 결함
        - 마법 카드를 사용 할 때 필드 소환 하는 버튼이 안사라짐.  
        눌렀을 시 카드의 데이터 변화에는 미치지 않지만 시각적으로 오류로 보임
    - ### 버리기 버튼
        - 버리기 기능을 켠 상태로 손패 버튼이나 필드 pictureBox 클릭시 버리기 버튼이 나오지 않음.
    - ### 턴 종료 버튼
        - 턴 종료 시 손패 버튼이나, 필드 pictureBox 클릭시 필드 소환 하는 버튼이 활성화 됨.


## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정

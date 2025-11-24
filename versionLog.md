# WinForm04 Project 카드 게임 개발 1.0.0v
## 기능 설명
기본적인 전투 페이지를 만들어 카드 이미지, 능력치등을 시각적으로 보여줌으로 게임의 기초를 만든다.



- ## Form01
    - ### [Delay 기능](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L22-L34)
        - DateTime 함수를 만들어 현재 시간과 끝나는 시간을 정하여 끝나는 시간에 도달할 때까지   
        시스템을 지연 시키는 함수이다.  
        기존의 Thead.Sleep과 다르게 UI 이벤트 시스템을 정지 하지 않는다.
    - ### [카드 이미지 (Resources)](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L55-L95)
        - 카드 이미지는 Resources 폴더를 사용하여 이미지를 저장 시킨후 구조체 배열에 등록 시킴과  
        동시에 각각 카드의 능력치를 Random 난수로 정한다.
    - ### [Form1_Click](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L106-L127)
        - 바탕 화면을 클릭 했을 경우에 내가 선택한 카드가 비 선택 카드로 되돌아 간다.
    - ### [HandCardAdd_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L128-L200)
        - 카드 뽑기 버튼을 눌렀을때 플레이어 손패 (button1~button5)에 CardDB에 저장된 카드의  
        이미지와 능력치가 대입된다.
    - ### [Delete_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L201-L258)
        - 카드 버리기 버튼을 눌렀을때 플레이어 손패에 카드가 있다면 버리기 기능이 사용된다.  
            또한 필드에 올린 카드도 버리기가 가능하다.
    - ### [End_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L259-L474)
        - 플레이어 턴이 종료 했다면 적 전투 필드에 각 Random 난수를 통해 적 카드가 필드에 배치되며,  
        서로의 카드가 있는 경우와 없는경우, 한쪽만 있는 경우를 나누어 전투를 거쳐간다.
    - ### [FieldCardAdd_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L474-L874)
        - 플레이어 손패에 있는 카드를 선택후 필드 소환 버튼 (button6~button10)을 클릭하면  
        손패 카드의 데이터가 필드 데이터로 이동한다.
        - CardAdd_button1~5까지는 똑같은 소스 코드
    - ### [Card_Button](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L875-L1094)
        - 플레이어 손패 카드를 선택 했을 때 카드의 정보를 불러오거나, 버리기 기능이 켜져있다면 카드를 버린다.
        - Card_button1~5까지는 똑같은 소스 코드
    - ### [double_Click](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L1099-L1104)
        - 카드를 더블 클릭하게 된다면 카드의 상세 정보가 나온다.
    - ### PictureBox (1-10)
        - 전투 필드 카드 공간이며, 카드의 이미지와 능력치가 시각적으로 보이며,  
        PictureBox에 마우스 클릭값을 인식하는 코드가 있지만 구별감이 없어, 밑에 보조 button을 사용한다.
    - ### button (1-5, 6-10)
        - (1-5)  
        손패 카드 공간이며, 카드의 이미지와 능력치가 시각적으로 보이며,  
        button 클릭했을때 눌림과 누르지않음이 구별되어 있어 플레이어가 선택한 모습이 시각적으로 보인다.
        - (6-10)  
        손패 카드를 전투 필드로 올리는 버튼이며, 손패 카드의 데이터를 전투 필드 데이터로 옮긴다.
    - ### TextBox1
        - 카드의 변경 사항이나 전투 상황을 알리는 Text기반 UI이다.


## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정

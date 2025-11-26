# WinForm04 Project 카드 게임 개발 4.4.5v
## 기능 설명
설정 창을 통해 세부적인 조정이 가능하며, 게임을 처음 접함 플레이어들을 위한 튜토리얼을 개발.  
인게임 중 폰트를 변경이 가능하고, 전체화면, 창 모드 등 부가적 기능을 추가.  
전투 밸런스 추가 및 전투 이펙트 추가.



- ## Form01
    - ### [부가 기능 설정 창](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L146-L150)
        - Form4에 만들어 둔 부가 기능 설정 창을 연결하여 Form4()의 UI와 값을 불러온다.
    - ### [승패 판정 이펙트](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L514-L521)
        - [Graphics 클래스](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L436-L445)를 사용하여 직관적인 네모칸을 만들고, [Pen 클래스](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L451-L452)를 사용하여 승패 판정을 알아 볼 수 있는  
        네모칸 색 변경으로, 시각적 효과를 볼 수 있다.
    - ### [데미지 반감 기능](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L531-L555)
        - 플레이어가 턴 종료 할 경우, 마주보고 있는 카드끼리 전투를 시작하는데 앞서 마주보고 있는 카드의 능력치를   
        비교하여 더큰 값을 가지고 있는 카드는 전체 데미지의 50%만 받는다.  
        (정수 값 계산식을 사용하여 소수점 일 경우 0.5는 소멸 된다 5 / 2 = 2.5 -> 2)
- ## Form03
    - ### [튜토리얼](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form3.cs)
        - 게임에 처음 접하는 플레이어들을 위한 게임 사용 설명서로 설명서의 이미지는  
        Resource에 넣어둔 이미지 파일을 불러와 시각적인 자료를 보여준다.
        - 버튼을 눌렀을때 증감식을 사용하여 정수의 값이 바뀌며 각 값에 맞는 이미지와 설명란이 바뀐다.
- ## Form04
    - ### [설정창](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form4.cs)
        - 부가적 기능을 조절이 가능한 메인 화면이며, 게임 난이도, 튜토리얼, 전체화면/창화면 변경, 폰트 변경 등  
        게임 외적인 부분을 모집하여 제작한 화면이다. 
    - ### [폰트 설정](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form1.cs#L152-L172)
        - 인게임 내부에서 TextBox를 사용한 모든 글자의 폰트를 본인의 취향대로 변경이 가능하다.
    - ### [화면 비율 조절](https://github.com/BestBlackCube/WinForm04Project/blob/main/C3%20Form%20testing/Form4.cs#L58-L71)
        - Form4 전체화면/창화면의 체크박스 체크 여부의 값을 가져와 Form1에 있는 전체화면 비율과 창 화면 비율을  
        나누어 불러온 값에 맞게 게임 화면의 크기가 변경된다.
    - ### 난이도 설정
        - 이전과 같이 Form2의 화면을 참조하여 중간에 난이도를 재설정 가능하다.
    - ### 튜토리얼
        - 튜토리얼 Form3을 참조하여 언제든지 튜토리얼을 볼 수 있다.
    - ### 화면 비율 조절
        - 체크 박스를 사용하여 전체화면과 창 화면을 언제든지 취향대로 조절 할 수 있다.

- ## 버그
    - ### 난이도 설정 버튼 이외의 클릭
        - 난이도 선택 페이지가 나온 상태로 뒷 배경에 있는 UI 클릭 시 실행 되는 버그
    - ### 빈화면 필드 소환
        - 손패에서 사용이 안된 카드를 클릭후 빈 손패 카드를 클릭 시 빈 카드가 선택되며 필드에 소환이 가능하며,  
        아무 데이터가 없는 빈공간으로 필드가 잠기는 버그

## 버전 업데이트 지연
```
NA.NA.4v 업데이트 지연
    1.1.0v -> 1.1.1v
    - 마법 카드 사용시 캐릭터 카드에 사용하는 것이 아닌 필드에 소환되는 버그
    - 버리기 기능 사용시 카드가 없어도 없어지는 버그

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

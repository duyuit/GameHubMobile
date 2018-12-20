
### 4.1 XÂY D Ự NG Ứ NG D Ụ NG

#### 4.1.1 Gi ớ i thi ệ u t ổ ng quan ki ến trúc chương trình
Chương trình xây dựng dựa trên 6 Activity chính để thực hiên các chức năng
chính:
 Login
 Register
 Home
 Game List
 Game Detail
 Game Library
 Payment
```
#### 4.1.2 Chi ti ế t các thành ph ầ n

```
Login: Cung cấp cho người dùng các trường để nhập tài khoản, mật
khẩu để đăng nhập vào phần mềm. Khi đăng nhập, phần mềm gửi thông tin
đăng nhập tới backend API để kiểm tra. Nếu thông tin đăng nhập đúng, API
sẽ trả về kết quả true và 1 user-id của người dùng.
```
```
Register: Cung cấp cho người dùng các trường để nhập thông tin cho
tài khoản cần đăng kí vào phần mềm. Khi ấn đăng kí, phần mềm gửi thông
tin đăng kí tới backend API để kiểm tra. Nếu thông tin đăng kí không bị
trùng, không bị lỗi định dạng, API sẽ trả về kết quả thành công. (Ngược lại
sẽ gửi thông tin lỗi).
```
```
Home: Cung cấp các danh mục quảng cáo cho game như đang sale,
đang hot, nhiều người chơi gần đây nhất. Các thông tin được lấy từ
API.(Backend có 1 bảng chứa thông tin quảng cáo: GameID nào đang sale,
sale bao nhiêu %).
```
```
Game list: Chứa một danh sách tất cả các game của cửa hàng cùng với
một số thông tin như tên game, nhà sản xuất, giá. Có các chức năng cơ bản
như tìm kiếm theo tên, sắp xếp theo giá, lọc game free và có phí.
```

```
Game Detail: Hiển thị thông tin chi tiết của game như hình ảnh,
content, thể loại, độ tuổi người chơi.
```
```
Game Library: Hiển thị những game đã được người dùng mua.
```
```
Payment: Khi người dùng chọn một game và tiến hành mua, giao diện
thanh toán sẽ được hiển thị chứa thông thanh toán của game, số tiền dư còn
lại của tài khoản.
```
### 4.2 CÁC THƯ VIỆ N S Ử D Ụ NG TRONG Ứ NG D Ụ NG

#### 4.2.1 Axios

- Axios là một thư viện HTTP Client dựa trên Promise. Cơ bản thì nó cung cấp
một API cho việc xử lý XHR (XMLHttpRequests).

#### 4.2.1 ImageSlider

- Một thư viện cung cấp một view hỗ trợ xem ảnh dưới dạng lướt, có hỗ trợ
tự động chuyển ảnh với animation.

#### 4.2.2 React Native Base

- Một thư viện hỗ trợ sẵn những component rất tiện lợi dựa trên thư viện React
Native


### 4.3 GIAO DI ỆN CHƯƠNG TRÌNH

#### 4.3.1 Giao di ệ n Login..................................................................................................


#### 4.3.2 Giao di ện đăng kí

##### .


#### 4.3.3 Giao di ệ n Home


#### 4.3.4 Giao di ệ n Game Detail

##### .


#### 4.3.5 Giao Game List


#### 4.3.6 Giao di ệ n Game Library


4.3.7 Giao di _ệ_ n Payment



### 4.4 CÀI ĐẶ T VÀ KI Ể M TH Ử

#### 4.3.1 Môi trườ ng

+Phát triển dựa trên môi trường Android

+Phiên bản android yêu cầu là Android 6.0 hay API 24 trở lên.

+Thiết bị có cài đặt Google Service 11.2 trở lên

+ASP.net core

+ SQL Server

#### 4.3.2 Th ử nghi ệm và đánh giá kế t qu ả

- Cài đặt Server

+ Run Project Server vơi android studio 2017

+Gõ lệnh update-database trong console nuget để cập nhật database

#### 4.3.3 Th ử nghi ệm và đánh giá kế t qu ả

Thử nghiệm:

```
 Quá trình thử nghiệm diễn ra có và trục trặc nhưng đã được khắc phục.
 Các chức năng cuối cùng đã được hoàn thành và đúng như mong
muốn.
 Cơ sở dữ liệu và file nén Project được sao lưu.
```
```
Đánh giá kết quả:
```
```
 Về cơ bản đã hoàn thành xong các chức năng mà yêu cầu đặt tả đặt ra.
 Giao diện bắt mắt, thân thiện, dễ nhìn.
 Nhìn chung đã hoàn thành tốt ứng dụng một cách cố gắng nhất.
```

## K Ế T LU ẬN VÀ HƯỚ NG M Ở R Ộ NG

```
Sau thời gian dài tìm hiểu và hoàn thành đồ án, chúng em cảm thấy rất vui vì
những kiến thức mới đã đạt được. Và cảm thấy vui vì những chỉ dẫn tận tình
của Thầy Cô.
```
```
Đồ án nhóm chúng em nhìn chung đã hoàn thành tất cả các chức năng yêu
cầu đặt tả đặt ra, nhưng đâu đó chắc chắn vẫn còn những thiếu sót, mà trong
tầm nhìn hạn hẹp chúng em vẫn chưa thấy được. Nên nhóm chúng em quyết
định sẽ dành thời gian tìm hiểu nâng cấp thêm nữa các chức năng bổ sung và
giao diện bắt mắt hơn nữa cho ứng dụng trong thời gian sắp tới.
```
```
Hướng mở rộng sẽ là thêm tài khoản đăng nhập và lưu trữ các thông tin cá
nhân của người dùng, dựa vào đó nhà phát triển có thể thông tin đến người
dùng một cách nhanh chóng và đầy đủ nhất. Ngoài ra còn liên kết với các
trang Web của từng nhà hàng, sẽ có chi tiết hơn nữa cho mỗi nhà hàng được
chọn.
```
```
Cuối cùng nhóm em xin cảm ơn Thầy Cô đã tận tình chỉ dạy và xin hứa sẽ
nghiên cứu và học tập thật tốt trong thời gian sắp tới.
```

## MÃ NGU Ồ N M Ở VÀ TÀI LI Ệ U THAM KH Ả O

[1] https://facebook.github.io/react-native/

[2] https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2



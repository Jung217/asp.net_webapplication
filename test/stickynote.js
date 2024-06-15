// 获取面板元素
const board = document.querySelector("#board");
let highestZIndex = 1;

// 创建便利贴
function createStickyNote() {
    // 创建一个div作为便利贴
    const sticky = document.createElement("div");
    sticky.classList.add("stickynote");
    sticky.style.zIndex = highestZIndex;

    // 为便利贴设置随机颜色
    const colorMap = ['#dcc7e1', '#bfd1b1', '#f9d3e3', '#aed0ee', '#fffbc7', '#f0c2a2'];
    sticky.style.backgroundColor = colorMap[board.children.length % 6];

    // 创建文本输入框
    const text = document.createElement("textarea");
    text.type = "text";
    text.placeholder = "Drag Me";
    text.maxLength = 100;
    text.classList.add("stickynote-text");
    sticky.appendChild(text);
    board.appendChild(sticky);

    // 实现文本框的自动增高
    text.addEventListener('input', () => {
        text.style.height = 'auto';
        text.style.height = (text.scrollHeight) + 'px';
    });

    // 实现拖拽功能
    let isDragging = false;
    let startX, startY, offsetX, offsetY;
    sticky.addEventListener('mousedown', (e) => {
        isDragging = true;
        // 计算拖动位置的偏移量
        startX = e.clientX;
        startY = e.clientY;
        offsetX = e.clientX - sticky.getBoundingClientRect().left;
        offsetY = e.clientY - sticky.getBoundingClientRect().top;
        // 确保新创建的便利贴显示在其他便利贴的上方
        highestZIndex++;
        sticky.style.zIndex = highestZIndex;
    });

    // 移动端拖拽
    sticky.addEventListener('touchstart', (e) => {
        isDragging = true;
        const touch = e.touches[0];
        startX = touch.clientX;
        startY = touch.clientY;
        offsetX = touch.clientX - sticky.getBoundingClientRect().left;
        offsetY = touch.clientY - sticky.getBoundingClientRect().top;
        highestZIndex++;
        sticky.style.zIndex = highestZIndex;
    });

    // 实时更新拖拽位置
    document.addEventListener('mousemove', (e) => {
        if (isDragging) {
            sticky.style.left = e.clientX - offsetX + 'px';
            sticky.style.top = e.clientY - offsetY + 'px';
        }
    });

    // 移动端实时更新拖拽位置
    document.addEventListener('touchmove', (e) => {
        if (isDragging) {
            const touch = e.touches[0];
            sticky.style.left = touch.clientX - offsetX + 'px';
            sticky.style.top = touch.clientY - offsetY + 'px';
        }
    });

    // 结束拖拽移动
    document.addEventListener('mouseup', () => {
        if (isDragging) {
            isDragging = false;
        }
    });

    // 移动端结束拖拽移动
    document.addEventListener('touchend', () => {
        if (isDragging) {
            isDragging = false;
        }
    });

    // 双击删除便利贴
    sticky.addEventListener("dblclick", () => {
        sticky.remove();
    });

    // 处理文本框的焦点事件
    text.addEventListener("focus", () => {
        isDragging = false;
    });

    text.addEventListener("blur", () => {
        isDragging = false;
    });
}

// 创建102个便利贴
for (let i = 0; i < 102; i++) {
    createStickyNote();
}

using System;

[Serializable]
public class PlayerData
{
    public long gold = 10000; //��
    public int count = 100; //���� ī��Ʈ
    public int saveCount = 100; //��ü ī��Ʈ
    public int dil = 100; //�Ҽ��� ī��Ʈ
    public float clickDelay = 1.00f; //��ü ������ �ð�
    public int clickDelayCount = 92; //������ ���׷��̵� Ƚ��
    public int CgoldByUpgrade = 1000; //Ŭ�� ���׷��̵带 ���� �ʿ��� ��
    public int CupgradeNum = 1000; //Ŭ�� ���׷��̵��� ��·�
    public int DgoldByUpgrade = 1000; //������ ���׷��̵带 ���� �ʿ��� ��
    public int DupgradeNum = 1000; //������ ���׷��̵��� ��·�
    public int clickTotal = 0; // �����˹ٿ� Ŭ�� Ƚ�� ����
    public int maxClickInTimer = 0; // �����˹ٿ� �ð����� �ִ� Ŭ�� Ƚ��
}

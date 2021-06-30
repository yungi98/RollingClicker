using System;

[Serializable]
public class PlayerData
{
    public long gold = 10000; //돈
    public int count = 100; //감소 카운트
    public int saveCount = 100; //전체 카운트
    public int dil = 100; //소수점 카운트
    public float clickDelay = 1.00f; //전체 딜레이 시간
    public int clickDelayCount = 92; //딜레이 업그레이드 횟수
    public int CgoldByUpgrade = 1000; //클릭 업그레이드를 위해 필요한 돈
    public int CupgradeNum = 1000; //클릭 업그레이드의 상승량
    public int DgoldByUpgrade = 1000; //딜레이 업그레이드를 위해 필요한 돈
    public int DupgradeNum = 1000; //딜레이 업그레이드의 상승량
    public int clickTotal = 0; // 빠른알바에 클릭 횟수 총합
    public int maxClickInTimer = 0; // 빠른알바에 시간동안 최대 클릭 횟수
}
